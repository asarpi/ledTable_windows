// LED_light.h

#include "config.h"

#ifndef _LED_LIGHT_h
#define _LED_LIGHT_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

/*
Note: Mivel PWM jelet k�ld�nk ki, ez�rt m�r 1-es �rt�kn�l bekapcsolnak a LED-ek
*/

class LED_light {
private:
	uint8_t s_led_pin;
	
	float temp_linearization;
	uint8_t duty;
	/*
	A LED egy nemline�ris eszk�z. Ergo a vil�goss�g nem ar�nyosan n�vekszik a kiadott �rt�kkel, hanem k�bgy�k�sen.
	Ez�rt j� �reg k�b f�ggv�ny�nket seg�ts�g�l h�vva kompenz�ljuk ezt.
	*/
	uint16_t linearizator(uint16_t inputvalue) {
		temp_linearization = (float)inputvalue / 100; //leosztjuk 100-al, �gy m�r a [0,1] intervallumon dolgozunk
		return (uint8_t)(pow(temp_linearization, 3)*255); //k�bgy�k, �s a teljes tartom�ny annyiszoros�t vessz�k
	}
	uint8_t linearizator_in255interval(uint16_t inputvalue) {
		inputvalue = 
		return (uint8_t)(pow((float)inputvalue / 255, 3) * 255);
	}

public:
	LED_light(byte ledpin) {
		s_led_pin = ledpin;
		pinMode(s_led_pin, OUTPUT);
	}
	LED_light() {} //csak akkor szabad �gy inicializ�lni, ha valamikor valahogy m�gis be�ll�tjuk a LED PINj�t kimenetk�nt
	/*
	Ezzel a f�gv�nnyel k�ldj�k ki a megfelel� vil�goss�g�rt�khez tartoz� PWM kit�lt�si t�nyez�t.
	A k�v�nt vil�goss�g �rt�ket 0-100 intervallumon v�rjuk
	*/
	void setlight(uint16_t lightvalue) {
		lightvalue = THRESHOLD(lightvalue, 0, 100);
		analogWrite(s_led_pin, linearizator(lightvalue));
	}
	/*
	* [0,255] intervallumon val� vil�goss�g �tad�s
	*/
	void setlight_255(uint8_t lightvalue) {
		lightvalue = THRESHOLD(lightvalue, 0, LIGHT_MAX_VALUE);
		analogWrite(s_led_pin, linearizator_in255interval(lightvalue));
	}
	/*
	A hagyom�nyos �ton t�rt�n� kit�lt�si t�nyez� �tad�s (csak �tadjuk a kit�lt�si t�nyez�t)
	[0,255] k�z�tti �rt�ket esz meg
	*/
	void setlight_old(uint8_t lightvalue) {
		lightvalue = THRESHOLD(lightvalue, 0, 255);
		analogWrite(s_led_pin, lightvalue);
	}
	void on() {
		setlight(LIGHT_MAX_VALUE);
	}

	void off() {
		setlight(LIGHT_MIN_VALUE);
	}

};



#endif

