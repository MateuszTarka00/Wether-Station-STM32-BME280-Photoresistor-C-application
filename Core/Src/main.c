#include "main.h"
#include "adc.h" //plik inicjalizacyjny ADC
#include "i2c.h" //plik inicjalizacyjny magistrale I2C
#include "usart.h" // plik inicjalizacyjny komunikacje USART
#include "gpio.h" // plik inicjalizacyjny wykorzystywane piny
#include "string.h"
#include "bme280_add.h" // funkcje sterownika czujnika
#include "bme280_defs.h" // Dane czujnika
#include <stdio.h>

void SystemClock_Config(void);

int main(void)
{
//funkcje inicjalizujące zegar, wejść i wyjść oraz funkcji pinów
  HAL_Init();
  SystemClock_Config();
  MX_GPIO_Init();
  MX_ADC1_Init();
  MX_I2C1_Init();
  MX_USART2_UART_Init();

  if(BME280_init() != BME280_OK) //Załączenie pracy czujnika
  {
	 char msg_init[15] = "error init\n\r"; // W momencie błędu, wysyłany o tym jest komunikat do komputera
	 HAL_UART_Transmit(&huart2,(uint8_t*)msg_init,sizeof(msg_init),1000);
 }

  uint16_t raw; // napięcie pobierane z dzielnika z rezystorem i fotorezystorem

  while (1) // głowna pętla programu
  {
	 if(BME280_read_data() != BME280_OK) // funkcja pobierające przetworzone dane z czujnika
	 {
		 char msg_read[20] = "read error \r\n"; // W momencie błędu, wysyłany jest o tym komunikat do komputera
		 HAL_UART_Transmit(&huart2,(uint8_t*)msg_read,sizeof(msg_read),1000);
	 }

	  char msg[10];
	  HAL_ADC_Start(&hadc1); // inicjalizacja przetwarzania ADC
	  HAL_ADC_PollForConversion(&hadc1, HAL_MAX_DELAY); // pobranie przetworzonego napięcia do handlera
	  raw = HAL_ADC_GetValue(&hadc1); // pobranie danych do zmiennej

	  sprintf(msg, " %d\r\n", raw); // konwersja napięcia na string
	  HAL_UART_Transmit(&huart2, (uint8_t *)msg, sizeof(msg), HAL_MAX_DELAY);
	  HAL_Delay(250); //opóźnienie następnego poboru danych

  }

}


void SystemClock_Config(void) //konfiguracja  sygnału zegarowego
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_HSI;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_I2C1|RCC_PERIPHCLK_ADC1;
  PeriphClkInit.I2c1ClockSelection = RCC_I2C1CLKSOURCE_HSI;
  PeriphClkInit.Adc1ClockSelection = RCC_ADC1PLLCLK_DIV1;

  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{

  if (htim->Instance == TIM1) {
    HAL_IncTick();
  }
}

void Error_Handler(void)
{
  __disable_irq();
  while (1)
  {
  }

}

#ifdef  USE_FULL_ASSERT

void assert_failed(uint8_t *file, uint32_t line)
{

}
#endif


