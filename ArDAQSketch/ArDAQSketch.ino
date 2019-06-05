#include <Wire.h>
#include <Adafruit_ADS1015.h>
#include <EEPROM.h>

typedef Adafruit_ADS1115* ads_ptr;



#include "Wire.h"
extern "C" { 
#include "utility/twi.h"  // from Wire library, so we can do bus scanning
}
     
#define TCAADDR 0x70 //address of the TCA9548A multiplexer
#define VERBOSE 0

ads_ptr ads1115_array[8][4];

uint8_t addr_ads1115[4] = {0x48, 0x49, 0x4A, 0x4B};  // the four possible address' of each ads1115 module
int init_value = 0;

int entry_status [8];
int stop_acq = 0;
void tcaselect(uint8_t i) {
  if (i > 7) return;
    
  Wire.beginTransmission(TCAADDR);
  Wire.write(1 << i);
  Wire.endTransmission();  


}
     
     
// standard Arduino setup()
void setup()
{
    while (!Serial);
    delay(1000);
    //
    Wire.begin();
    
    
    Serial.begin(115200);
    Wire.setClock(400000);
    TWBR = ((F_CPU /40000l) - 16) / 2; // Change the i2c clock to 400KHz
    
    if (VERBOSE) Serial.println("\nTCAScanner ready!");
    
    for (uint8_t t=0; t<3; t++) {
      tcaselect(t);
      if (VERBOSE) Serial.print("TCA Port #");
      if (VERBOSE) Serial.print(t);
      if (VERBOSE) Serial.print("on address : 0x");
      if (VERBOSE) Serial.println(TCAADDR, HEX);
        
      for (uint8_t addr = 0; addr<=127; addr++) {
        //if (addr == TCAADDR) continue;
          
        uint8_t data;
        if (! twi_writeTo(addr, &data, 0, 1, 1)) {
            if (VERBOSE) Serial.print("Found I2C 0x");
            if (VERBOSE) Serial.println(addr,HEX);
        }
      }
      for (int j=0; j<4; j++){
        ads1115_array[t][j] = new Adafruit_ADS1115(addr_ads1115[j]);
        ads1115_array[t][j]->begin();

        if (VERBOSE) Serial.print("ADS1115 on address ");
        if (VERBOSE) Serial.print(addr_ads1115[j], HEX);
        if (VERBOSE) Serial.println(" initialized");
        
      }
    }
}

void serialEvent() {
  if (init_value==0)
  {
    for (uint8_t t=0; t<8; t++) {
      while(Serial.available()==0);
      //Serial.println(Serial.available());
      char charValue[2];
      charValue[0] = Serial.read();
      //charValue[1] = "\0";
      int val = atoi(charValue);
      entry_status[t] = val;
      /*Serial.print(t);
      Serial.print(" ");
      Serial.print(charValue);
      Serial.print(" ");
      Serial.println(val); 
      */
    }
    init_value =1;
  }

  else
  {
    if(Serial.available()){
      char charValue[2];
      charValue[0]= Serial.read();
      //charValue[1] = "\0";
      stop_acq = atoi(charValue);

    }
  }
}
void loop() 
{

  if ((init_value==1) &&(stop_acq ==0)){
    double gain = 0.1875;
    String mesg = "";
    int16_t results;
    for (uint8_t t=0; t<8; t++) 
    {
      if (entry_status[t]!=0)
      {
        tcaselect(t);
        if (VERBOSE) Serial.print("tca select ");
        if (VERBOSE) Serial.print(t);
        if (VERBOSE) Serial.print("on address : 0x");
        if (VERBOSE) Serial.println(TCAADDR, HEX);
        for (int j=0; j<4; j++)
        {
          ads1115_array[t][j]->setGain(GAIN_TWOTHIRDS);
          
          results = ads1115_array[t][j]->readADC_Differential_0_1();
          mesg += results * gain ;
          mesg += " ";
          
          results = ads1115_array[t][j]->readADC_Differential_2_3();
          mesg += results * gain ;
          mesg += " ";
        }
      }
    }
    Serial.println(mesg);
  }
  delay(10);
}
