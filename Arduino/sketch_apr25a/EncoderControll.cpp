#include "Arduino.h"
#include "EncoderControll.h"


EncoderControll::EncoderControll(int pin1,int pin2)
{

  encoder = new Encoder(pin1,pin2);
}

void EncoderControll::SetResolution(int *value)
{
  _resolution = *value;
}

void EncoderControll::ResetStartPosition()
{
  
  encoder->write(0); 
}

int EncoderControll::GetPositionPlain()
{
  long value = encoder->read();
  Serial.println(value);
  return (int)value;
}
    
int EncoderControll::GetPosition()
{
  long value = encoder->read();
  
  int mapped = map((int)value, 0, _maximum, 0, _resolution);
  
  return mapped;
}


void EncoderControll::SetMaximum(int *maximum)
{
 _maximum = *maximum; 
}
