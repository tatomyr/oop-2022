class Auto:
    rising_prices = 200
    number_of_auto = 0

    def __init__(self, marka, model, price, year, fuel):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.fuel = fuel
        self.short_description = marka + " " + model + "; " + str(price) + "$"
        Auto.number_of_auto += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nyear: " \
               + self.year + "\nfuel: " + self.fuel

    def apply_rising(self):
        self.price = self.price + self.rising_prices

    # Створив альтернативний конструктор
    @classmethod
    def from_string(cls, aut_str):
        marka, model, price, year, fuel = aut_str.split("-")
        return cls(marka, model, price, year, fuel)

    # Метод класу який працює зі змінною класу
    @classmethod
    def set_price_auto(cls, aut_price):
        cls.rising_prices = aut_price
        # Статичний метод

    @staticmethod
    def is_low_price(price):
        if price < 2000:
            return True
        return False


aut_str_1 = "Nissan-Xtral-4000-2014-diesel"
new_aut_1 = Auto.from_string(aut_str_1)
print(new_aut_1.short_description)

car1 = Auto("Fiat", "500", 3000, "2017", "benzin 95")
Auto.set_price_auto(3000)
print(car1.rising_prices)

print(Auto.is_low_price(car1.price))