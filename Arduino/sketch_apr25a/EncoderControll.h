#ifndef EncoderControll_h
#define EncoderControll_h

#include "Arduino.h"
#include <Encoder.h>

class EncoderControll
{
  public:
    EncoderControll(int pin1,int pin2);

    void SetResolution(int *value);
    void ResetStartPosition();
    
    
    int GetPosition();
    int GetPositionPlain();
    
    void SetMaximum(int *maximum);
  private:
     int _resolution = 500;
     int _maximum = 4096;
     Encoder *encoder;
    
};


#endif
