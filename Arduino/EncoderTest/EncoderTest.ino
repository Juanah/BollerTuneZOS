/* Encoder Library - Basic Example
 * http://www.pjrc.com/teensy/td_libs_Encoder.html
 *
 * This example code is in the public domain.
 */
//#define ENCODER_OPTIMIZE_INTERRUPTS
#include <Encoder.h>

// Change these two numbers to the pins connected to your encoder.
//   Best Performance: both pins have interrupt capability
//   Good Performance: only the first pin has interrupt capability
//   Low Performance:  neither pin has interrupt capability
Encoder encoderMotor = Encoder(2,8);
Encoder myEnc(3, 9);
//   avoid using pins with LEDs attached

void setup() {
  Serial.begin(9600);
  Serial.println("Basic Encoder Test:");
}

long oldPosition  = -999;

void loop() {
  long newPosition = myEnc.read();
  long pos2 = encoderMotor.read();
  Serial.print(newPosition);
  Serial.print(":");
  Serial.println(pos2);
  
  if (newPosition != oldPosition) {
    oldPosition = newPosition;
    

  }
}
