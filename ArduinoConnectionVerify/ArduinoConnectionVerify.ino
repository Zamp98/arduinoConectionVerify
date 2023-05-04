
int msgSize = 50;

char incomingChar;


char * initMsg(){
  char * msg = (char*)malloc(sizeof(char)*msgSize);
  for(int i = 0; i<msgSize; i++){
      msg[i] = '\0';
    }
    return msg;
}

void setup() {
  Serial.begin(9600);
  initMsg();
}

void loop() {
  //Serial.println("oi");
  if (Serial.available() > 0) {
    // read the incoming byte:
    char * msg = initMsg();
    for(int i = 0; i<msgSize; i++){
      incomingChar = Serial.read();
      msg[i] = incomingChar;
      
    }

    Serial.println(msg);
    free(msg);
    
  }
  delay(2000);
}