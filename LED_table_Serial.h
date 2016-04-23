// LED_table_Serial.h

#ifndef _LED_TABLE_SERIAL_h
#define _LED_TABLE_SERIAL_h


#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif



#include <stdio.h>
#include <string.h>
#include "config.h"

#define DEBUG 0 

enum preDefined_messages_enum {
	msg_ACK = 10,
	msg_CMD_ACK = 11,
	msg_SPEC_DELAYTIME = 50,
	msg_NOT_ACK = 99,
	msg_CMD_NOT_ACK = 98,
	msg_ACTUALSTATE = 1

}pD_messages;
//template: 01_34_678_012_456_89
enum commands {
	cmd_setBlack =				0, //teljes s�t�ts�g
	cmd_setWhite =				1, //teljes vil�goss�g
	cmd_setRGB =				2, //k�v�nt RGB be�ll�t�sa
	cmd_SPECIAL_set_rgbDELAY =	3, //template indexek: 34 - cmd, 678 - delaytime
	cmd_goTo_Linear =			10,
	
	cmd_goTo_Linear_WithStep_2 = 11, //a k�v�nt RGB kombin�ci� el�r�se N l�p�sben line�ris sk�l�n haladva
	cmd_goTo_Linear_WithStep_5 = 12,
	cmd_goTo_Linear_WithStep_10 = 13,
	cmd_goTo_Linear_WithStep_15 = 14,
	cmd_goTo_Linear_WithStep_30 = 15,
	cmd_goTo_Linear_WithStep_50 = 16,
	cmd_goTo_Linear_WithStep_65 = 17,
	cmd_goTo_Linear_WithStep_80 = 18,
	cmd_goTo_Linear_WithStep_100 = 19,


	cmd_goTo_Sine_WithStep_2 = 21, //a k�v�nt RGB kombin�ci� el�r�se N l�p�sben szinuszos sk�l�n haladva
	cmd_goTo_Sine_WithStep_5 = 22,
	cmd_goTo_Sine_WithStep_10 = 23,
	cmd_goTo_Sine_WithStep_15 = 24,
	cmd_goTo_Sine_WithStep_30 = 25,
	cmd_goTo_Sine_WithStep_50 = 26,
	cmd_goTo_Sine_WithStep_65 = 27,
	cmd_goTo_Sine_WithStep_80 = 28,
	cmd_goTo_Sine_WithStep_100 = 29,

	cmd_goTo_Exp = 30,				//exponenci�lis teljes kivil�gosod�s, majd els�t�t�l�s, majd visszat�r�s az eredeti �rt�khez
	cmd_goTo_Exp_WithStep_2 =	31, //a k�v�nt RGB kombin�ci� el�r�se N l�p�sben exponenci�lis sk�l�n haladva
	cmd_goTo_Exp_WithStep_5 =	32,
	cmd_goTo_Exp_WithStep_10 =	33,
	cmd_goTo_Exp_WithStep_15 =	34,
	cmd_goTo_Exp_WithStep_30 =	35,
	cmd_goTo_Exp_WithStep_50 =	36,
	cmd_goTo_Exp_WithStep_65 =	37,
	cmd_goTo_Exp_WithStep_80 =	38,
	cmd_goTo_Exp_WithStep_100 =	39,

	cmd_wave_AllInterVal =		50, // a teljes intervallumon v�gighalad�s szinuszos hull�mmal, majd visszat�r�s az eredeti �rt�khez
	cmd_wave_Step20_cyc1 =		51,//a k�v�nt RGB kombin�ci�j� amplitud�val ingadoz�s szinuszosan N l�p�sben �s M cikluson kereszt�l
	cmd_wave_Step40_cyc1 =		52,
	cmd_wave_Step60_cyc1 =		53,
	cmd_wave_Step20_cyc2 =		54,
	cmd_wave_Step40_cyc2 =		55,
	cmd_wave_Step60_cyc2 =		56,
	cmd_wave_Step20_cyc3 =		57,
	cmd_wave_Step40_cyc3 =		58,
	cmd_wave_Step60_cyc3 =		59,

	cmd_get_ActualRGB =			91, //aktu�lis RGB kombin�ci� lek�rdez�se
	cmd_get_SPEC_rgbDelayTime = 92, //aktu�lis DELAY lek�rdez�se (a redLightValues mez�ben k�ldve, a t�bbi 0)
};

struct command_struct_t {
	int command;
	int redLightValue;
	int greenLightValue;
	int blueLightValue;
};

struct message_struct_t {
	int message;
	int redLightValue;
	int greenLightValue;
	int blueLightValue;
}message_struct;

struct rgbLights {
	int red;
	int green;
	int blue;
};

/*
*Protokoll le�r�sa
* 00 Msg RedLight GreenLight BlueLight 00
* az Msg, ha PC --> Arduino: �llapot
* az Msg, ha Arduino --> PC: ACK, vagy aktu�lis �llapot
* az �llapotok:
*		0 -- manu�lis ir�ny�t�s
*		1 -- 
*/


class Serial_protocol {
private:

	char readvalue;
	unsigned int valueLength;
	//char readString[];
	String value;
	String startValue;
	String stopValue;
	command_struct_t cmd;
	message_struct_t msg;
	

	void encode_2digits(uint8_t num, char &c_0, char &c_1) {
		uint8_t tens = num / 10;
		uint8_t ones = num - tens * 10;
		c_0 = char(tens + 48);
		c_1 = char(ones + 48);
		#if DEBUG
		Serial.print("te: "); Serial.print(tens); Serial.print(" on: "); Serial.print(ones); Serial.println();
		#endif
	}

	void encode_3digits(uint8_t num, char &c_0, char &c_1, char &c_2) {
		num = THRESHOLD(num, 0, 255);
		uint8_t hundreds = num / 100;
		uint8_t tens = (num - hundreds* 100) / 10;
		uint8_t ones = (num - hundreds * 100 - tens * 10);
		c_0 = char(hundreds + 48);
		c_1 = char(tens + 48);
		c_2 = char(ones + 48);
		#if DEBUG
		Serial.print("hu: "); Serial.print(hundreds); Serial.print("  te: "); Serial.print(tens); Serial.print("  on: "); Serial.print(ones); Serial.println();
		#endif
	}
	void encode_4digits(uint16_t num, char &c_0, char &c_1,
						char &c_2, char &c_3) {

		uint16_t thousands = num / 1000;
		uint16_t hundreds = (num - thousands * 1000) / 100;
		uint16_t tens = (num - thousands * 1000 - hundreds * 100) / 10;
		uint16_t ones = (num - thousands * 1000 - hundreds * 100 - tens * 10);
		c_0 = char(thousands + 48);
		c_1 = char(hundreds + 48);
		c_2 = char(tens + 48);
		c_3 = char(ones + 48);
		
	}




public:
	/*
	* Init f�ggv�n. Nem konstruktort haszn�lok, mert a Serial portot k�l�n kell inicializ�lni a .ino f�jl Setup() fv-�ben. (arduino saj�toss�g)
	* viszont m�gis global-nak kell maradnia az oszt�lyunk p�ld�ny�nak.
	*/
	void init() {
		Serial.begin(9600);
		delay(100);
		Serial.println(" ##### Good morning sir! #####");
	}
	/*
	* Met�dus string k�ld�s�re. EZT INK�BB NE HASZN�LD, MERT A T�LOLDALT NINCS R� GARANCIA, HOGY B�RKI MEGESZI !!!
	* csal debug c�lra.
	*/
	void sendString(char Msg[]) {
		Serial.println(Msg);
	}
	/*
	* Met�dus ACK k�ld�s�re. Ha szeretn�nk m�g a msg strukt�r�ban elt�rolhatunk RGB k�dokat
	* (pl. ha RGB k�dot kaptunk, akkor visszak�lj�k, hogy ezt kaptuk)
	*/
	void sendACKwithValues(message_struct_t message) {		
		message.message = msg_ACK;
		encodeAndSendMsg(message);
	}
	/*
	* not ACK k�ld�se, ha valami miatt a parancs v�grehajt�sa nem siker�lt
	*/
	void sendNOTACK() {
		msg.message = msg_NOT_ACK;
		msg.redLightValue = 999;
		msg.greenLightValue = 999;
		msg.blueLightValue = 999;
		encodeAndSendMsg(msg);
	}
	/*
	* Met�dus valamilyen el�re defini�lt �zenet k�ld�s�hez, vagy �llapot jelent�shez.
	*/
	void sendMsg(int Msg) {
		message_struct_t msg_struct;
		msg_struct.message = Msg;
		msg_struct.redLightValue = 0;
		msg_struct.greenLightValue = 0;
		msg_struct.blueLightValue = 0;
		encodeAndSendMsg(msg_struct);
	}
	/*
	* Met�dus �ezenet �s RGB �rt�kek k�ld�s�hez
	*/
	void send(message_struct_t message) {
		encodeAndSendMsg(message);
	}
	/*
	* F�gv�ny az msg_struck-ban �tadott inform�ci�k lek�dol�s�ra, �s ennek elk�ld�s�re a Serial porton kereszt�l.
	* Egy data stream template-nek megfelel� stringet �p�t�nk fel,aminek meg kell felelni, hogy a t�loldalt is ezt a szab�lyt k�vetve
	* mindig dek�dolhat� legyen az �zenet.
	* data stream template:
	* ha az indexek:: 01_34_678_012_456_89
	* akkor:
	*		"_" a szepar�tor karakter
	*		01 - Start karakterek. Ezeknek mindig "0"-nak �s "1"-nek kell lenni�k!
	*		34 - �zenet karakterek. Ezek defini�lnak egy �zenetet, amit a t�loldalon tudunk �rtelmezni. Ez lehet ak�r egy �llapotjelent�s, vagy ACK
	*		678- RED light �rt�kek
	*		012- GREEN light �rt�kek
	*		456- BLUE light �rt�kek
	*		89 - Stop karakterek. Ezeknek mindig "1"-nek �s "0"-nak kell lenni�k!
	* �gy �sszesen egy data stream 20 karakterb�l kell hogy �lljon
	*/

	void encodeAndSendMsg(message_struct_t msg_struct) {
		//msg indices:    01_34_678_012_456_89
		char message[] = "01_00_000_000_000_10";
		//encode msg 
		encode_2digits(msg_struct.message,  message[3], message[4]);
		encode_3digits(msg_struct.redLightValue  , message[6] , message[7] , message[8] );
		encode_3digits(msg_struct.greenLightValue, message[10], message[11], message[12]);
		encode_3digits(msg_struct.blueLightValue , message[14], message[15], message[16]);
		//send msg
		Serial.println(message);
	}
	/*
	* Met�dus az adatok olvas�s�ra, �s dek�dol�s�ra
	* Csak akkor kapunk el egy �zenetet, ha megfelel a data stream template-nek
	* data stream template:
	* ha a cmd indexei: 01_34_678_012_456_89
	* akkor:
	*		"_" a szepar�tor karakter
	*		01 - Start karakterek. Ezeknek mindig "0"-nak �s "1"-nek kell lenni�k!
	*		34 - command karakterek. Ezekb�l tudjuk meg, hogy mit �zen a PC, milyen m�veletet kell v�grehajtani
	*		678- RED light �rt�kek
	*		012- GREEN light �rt�kek
	*		456- BLUE light �rt�kek
	*		89 - Stop karakterek. Ezeknek mindig "1"-nek �s "0"-nak kell lenni�k!
	* �gy �sszesen egy data stream 20 karakterb�l kell hogy �lljon
	*
	* return: a programba visszat�r a dek�dolt �zenet strukt�r�j�val,
	*		  valamint a Serial porton k�ld egy ACK-t az kapott RGB k�ddal.
	*/
	command_struct_t readAndDecodeCmd() {
		
		//cmd indices:    01_34_678_012_456_89
		if (Serial.available()) {
			value = Serial.readString();
			valueLength = value.length();
			Serial.println(value);

			//Check
			if (valueLength == 20) {
				startValue = (String)value[0] + (String)value[1];
				stopValue = (String)(value[valueLength - 2]) + (String)(value[valueLength - 1]);
				if ((startValue = "01") && (stopValue == "10")) {
					//Check OK

					cmd.command = ((uint8_t)(value[3]) - 48) * 10 + ((uint8_t)(value[4]) - 48);
					cmd.redLightValue   = ((uint8_t)(value[6]) - 48) * 100 + ((uint8_t)(value[7]) - 48) * 10 + ((uint8_t)(value[8]) - 48);
					cmd.greenLightValue = ((uint8_t)(value[10]) - 48) * 100 + ((uint8_t)(value[11]) - 48) * 10 + ((uint8_t)(value[12]) - 48);
					cmd.blueLightValue  = ((uint8_t)(value[14]) - 48) * 100 + ((uint8_t)(value[15]) - 48) * 10 + ((uint8_t)(value[16]) - 48);
				}


			}
			//Give parameters to ACK sender in msg structure, and send ACK, because we are happy :-)
			msg.redLightValue = cmd.redLightValue;
			msg.greenLightValue = cmd.greenLightValue;
			msg.blueLightValue = cmd.blueLightValue;
			#if DEBUG
			Serial.println(value);
			Serial.print("cmd_state: "); Serial.print(cmd.command); Serial.println();
			Serial.print("r: "); Serial.print(cmd.redLightValue); Serial.print(" g: "); Serial.print(cmd.greenLightValue); Serial.print(" b: "); Serial.print(cmd.blueLightValue); 
			Serial.println();
			#endif	
			sendACKwithValues(msg);
		}
		return cmd;
	}
};

#endif