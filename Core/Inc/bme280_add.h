#ifndef INC_BME280_ADD_H_
#define INC_BME280_ADD_H_

int8_t BME280_init(void);
int8_t BME280_read_data(void);
void print_sensor_data(struct bme280_data *comp_data);
void delay_ms(uint32_t period);
int8_t i2c_read(uint8_t dev_id, uint8_t reg_addr, uint8_t *reg_data, uint16_t len);
int8_t i2c_write(uint8_t dev_id, uint8_t reg_addr, uint8_t *reg_data, uint16_t len);

#endif /* INC_BME280_ADD_H_ */
