#ifndef Log_h
#define Log_h

#include "Arduino.h"


class Log
{
  public:
    Log();
    
    void Write(String message);
    
    void WriteArray(String *messages);
  private:
    int useLog = 1;
    
};


#endif
