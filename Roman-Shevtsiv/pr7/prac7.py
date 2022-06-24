class watches:
    rising_prices = 50
    number_of_watches = 0

    def __init__(self, marka, model, price, year):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.short_description = marka + " " + model + "; " + str(price) + "$"
        watches.number_of_watches += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nyear: " \
               + self.year

    def apply_rising(self):
        self.price = self.price + self.rising_prices

    # Створив альтернативний конструктор
    @classmethod
    def from_string(cls, watch_str):
        marka, model, price, year = watch_str.split("-")
        return cls(marka, model, price, year)

    # Метод класу який працює зі змінною класу
    @classmethod
    def set_price_watch(cls, watch_price):
        cls.rising_prices = watch_price

    # Статичний метод
    @staticmethod
    def is_low_price(price):
        if price < 200:
            return True
        return False


watch_str_1 = "Xiaomi-Mi band3-200-2018"
new_watch_1 = watches.from_string(watch_str_1)
print(new_watch_1.short_description)

watch1 = watches("Xiaomi", "mi band2", 100, "2016")
watches.set_price_watch(100)
print(watch1.rising_prices)

print(watches.is_low_price(watch1.price))