#include "Arduino.h"
#include "Log.h"


Log::Log()
{
  if(useLog == 1)
  {
    Serial.begin(9600);
  }
  
}



void Log::Write(String message)
{
  if(useLog == 1)
  {
    Serial.println(message);
  }
  
}

void Log::WriteArray(String *messages)
{
  if(useLog == 0)
  {
    return;
  }
 
 int sizeOfArray = sizeof(messages);
  
  for(int i=0; i < (sizeof(messages) - 1);i++)
  {
     Serial.print(messages[i]);   
    
  }
  
  Serial.println(messages[(sizeOfArray -1)]);
  
}
