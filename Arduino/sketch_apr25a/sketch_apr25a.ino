#include <TimedAction.h>

#include "Log.h"
#include "EncoderControll.h"
#define ENCODER_OPTIMIZE_INTERRUPTS
#include <Encoder.h>
Encoder encoderMotor = Encoder(2,4);
Encoder encoderSteering = Encoder(3,7);



/*Processingpins*/
int turnRight = 13;
int turnLeft = 12;
int dataPin = 11;
int motorDataPin = 6;



/*TimedActions
*Processing Steering
*/

int directionState = 0;

int directionCounter = 0;

long lastTimeDirectionChanged;
Log _log;

//Speed of the Motor
int motorSpeed = 0;

void setup() {
  Serial.begin(9600);
  // put your setup code here, to run once:
  //_log.Write("Programm Start");
lastTimeDirectionChanged = millis();
//Controls


//pinMode(turnLeft,OUTPUT);
//pinMode(turnRight,OUTPUT);
//pinMode(dataPin,OUTPUT);
//pinMode(motorDataPin,OUTPUT);
//pinMode(motorPotiPin,INPUT);
  Serial.println("START");
}

void loop() {
  // put your main code here, to run repeatedly:
  ProcessSteering();
  ProcessMotorSpeed();
}

void ProcessMotorSpeed()
{
  /*
   int potiValue = analogRead(motorPotiPin);
  
  int calculatedValue = map(potiValue,0,1024,0,255);
 Serial.println(calculatedValue);
   analogWrite(motorDataPin, calculatedValue);
  */
}

void ProcessSteering()
{
    long motorPosition = encoderMotor.read();
    long steeringPosition = encoderSteering.read();

    
    long diff = steeringPosition - motorPosition;
    
    int directionValue = 0;
    directionState = 1;
    //Log::WriteArray
    if(diff < 0)
    {
      diff = diff * (-1);
      
       directionValue = 1;
    }
    
    directionCounter++;

    int cSpeed = 0;
    if(diff > 75)
    {
      if(directionValue == 1)
      {
        /*
        digitalWrite(turnRight,LOW);
        digitalWrite(turnLeft,HIGH);
        */
      }else
      {
        /*
       digitalWrite(turnRight,HIGH);
        digitalWrite(turnLeft,LOW); 
        */
      }
      long realDiff = diff;
      if(diff > 3000)
      {
       diff = 3000; 
      }
      cSpeed = map(diff,20,3000,0,255);
      Serial.print("MotorSpeed:");
      Serial.print(cSpeed);
      Serial.print("Diff:");
      Serial.println(diff);
      
      /*
       Serial.print("Differzen:");
       Serial.print(realDiff);
       Serial.print("Speed:");
       Serial.println(cSpeed);
      */
       //analogWrite(dataPin,cSpeed); 
    }else
    {
      /*
        digitalWrite(turnRight,HIGH);
        digitalWrite(turnLeft,HIGH);
        
      analogWrite(dataPin,0); 
      */
    }
    
    /*
    String speedStr = String(cSpeed);
    String *array = new String[6];
    array[0] = "PositionsDifferenz:";
    array[1] = diffStr;
    array[2] = "Richtung:";
    array[3] = directionSteering;
    array[4] = "Speed:";
    array[5] = speedStr;
    
    _log.WriteArray(array);
    */
}

