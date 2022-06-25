class baking:
    rising_prices = 5
    number_of_baking = 0
    def __init__(self, filling, name, price, date):
        self.filling = filling
        self.name = name
        self.price = price
        self.date = date
        self.short_description = filling + " " + name + "; " + str(price) + "$"
        baking.number_of_baking += 1

    def full_description(self):
        return "filling and name: " + self.filling + " " + self.name + ";\nprice: " + str(self.price) + "$\ndate of manufacture : " \
               + self.date

    def apply_rising(self):
        self.price = self.price + self.rising_prices


    #Створив альтернативний конструктор
    @classmethod
    def from_string(cls, baking_str):
        filling, name, price, date = baking_str.split("-")
        return cls(filling, name, price, date)

    # Метод класу який працює зі змінною класу
    @classmethod
    def set_price_baking(cls, baking_price):
        cls.rising_prices = baking_price

    # Статичний метод
    @staticmethod
    def is_low_price(price):
        if price < 10:
            return True
        return False


baking_str_1 = "chocolate - donat - 15 - 25.06.2022"
new_baking_1 = baking.from_string(baking_str_1)
print(new_baking_1.short_description)

baking1 = baking("nut", "nutcake", 20, "25.06.2022")
baking.set_price_baking(10)
print(baking1.rising_prices)

print(baking.is_low_price(baking1.price))
