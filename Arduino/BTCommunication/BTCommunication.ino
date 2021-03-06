
#include <SPI.h>       
#include <Ethernet.h>
#include <EthernetUdp.h>
#include "UDPConnectionInfo.h"
#include "UdpService.h"
#include "UDPClient.h"
#include "MessageProcessor.h"
#include "Message.h"


int *ledPin;
int counter = 0;
char ledBlinkType = 0x02;
char *clientAddress;
Message *incommingMessage;
Message *msg;

//Class which handles all the raw Communication
//Behandelt alle Netzwerkaktivitaeten, jedoch nur Primitive Datentypen also Bytes
UdpService * updService;
//ConnectionInfo for the udpService
//Verbindungsinformationen fuer den udpservice(Wichtig es muss ein Pointer sein)
UDPConnectionInfo *udpConnectionInfo;
//The MessageProcessor is the Part wich will be used to get Messages (Later also sending messages)
//Der MessageProcessor ist das Modul um Messages zu erhalten und spaeter auch zu verwenden(Muss auch ein Pointer sein!)
MessageProcessor *messageProcessor;

UDPClient *client;

Message *testResponse;


void setup() {
  Serial.begin(9600);
  
  
 
  //UdpConnectionInfo Instance will be initialized, it holds the ip,port and Macaddress
  //UdpConnectionInfo Instance wird erzeugt, diese hält die ip,port und macadresse
  udpConnectionInfo = new UDPConnectionInfo();
  //Initialize the service to listen on ip 192.168.2.177 on port 8888
  udpConnectionInfo->Initialize(192,168,2,177,8888);
  
  //UdpService Instance will be Initialized
  updService = new UdpService();
  //Passing the ConnectionInfo, and wich that starting the service
  updService->Init(udpConnectionInfo);
  //MessageProcessor will be Initialized and takes the udpService pointer which is nessary!
 //MessageProcessort wird initialisiert und nimmt den Pointer des udpservices an, dieser ist umbedingt noetig sonst laeuft nichts! 
  messageProcessor = new MessageProcessor(updService);
  
  clientAddress = new char[4];
  
  clientAddress[0] = 192;
  clientAddress[0] = 168;
  clientAddress[0] = 2;
  clientAddress[0] = 100;
  
  
  client = new UDPClient(192,168,2,100,9050);
  
  ledPin = new int[3];
  ledPin[0] = 3;
  ledPin[1] = 5;
  ledPin[2] = 6;
  
  pinMode(ledPin[0],OUTPUT);
  pinMode(ledPin[1],OUTPUT);
  pinMode(ledPin[2],OUTPUT);
  
  testResponse = new Message();
  testResponse->StartByte = 0x01;
  testResponse->EndByte = 0xDE;
  testResponse->Type = 0x02;
  testResponse->Data = new char[3];
  testResponse->Data[0] = 'O';
  testResponse->Data[1] = 'K';
  testResponse->Data[2] = '.';
  testResponse->Length = 3;
  
  
  
  
}

void loop() {
  
  /*Receive new MessageInstance from messageprocessor
  I higly recommend not to save multiply instances of Messages, 
  a Message can be quit big an can produce in very short time an Stackoverflow!
  
  Empfangen einer neuen Message vom MessageProcessor.
  Ich Empfehle sehr stark keine Messages im Speicher zubehalten,
  eine Message kann relativ gross sein und damit den Arbeitsspeicher zum ueberlaufen bringen!
  */
  incommingMessage = messageProcessor->ReceiveMessage();
  
  /*
  Every Message got an attribute 'isLegal', check it befor using the Message!
  
  Jede Message enthaelt das Attribut 'isLegal' welches angibt ob die Message 
  den vorschriften entspricht oder nicht. Vorher pruefen sonst koennte es gewaltig knallen!
  */
  
  if(incommingMessage->isLegal == 0x01)
  {  
    if(incommingMessage->Type == 0x02)
    {
      
       analogWrite(ledPin[0],(unsigned char) incommingMessage->Data[0]);
       analogWrite(ledPin[1],(unsigned char) incommingMessage->Data[1]);
       analogWrite(ledPin[2],(unsigned char) incommingMessage->Data[2]);
      
       Serial.println("Wrote");
       
       int result = messageProcessor->SendMessage(client,testResponse);
       
       Serial.println(result);
      
    }else if(incommingMessage->Type == 0x03)
    {
      analogWrite(ledPin[0],0);
       analogWrite(ledPin[1],0);
       analogWrite(ledPin[2],0);
      delay(600);
      
    }  
  }
}


int freeRam ()
{
extern int __heap_start, *__brkval;
int v;
return (int) &v - (__brkval == 0 ? (int) &__heap_start : (int) __brkval);
}


