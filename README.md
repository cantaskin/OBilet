# OBiletClone

OBiletClone, .NET 8 ile geliştirilmiş otobüs bileti rezervasyon sistemi.

---

## Kurulum ve Çalıştırma

1. **Projeyi klonlayın**

git clone https://github.com/kullaniciadi/OBiletClone.git

cd OBiletClone

2. **Docker ile tüm servisleri başlatın**

docker compose up --build

Bu kurulum 10-15 dk kadar sürebilir. 

## Uygulama Çalıştırıldıktan Sonra

Uygulama başarıyla başlatıldıktan sonra aşağıdaki adrese giderek API dokümantasyonuna (Swagger UI) erişebilirsiniz:

http://localhost:8000/swagger

Buradan API endpoint'lerini test edebilir ve kullanımı detaylıca inceleyebilirsiniz.

Admin User'ın 

email = admin@admin.io
password : Passw0rd!

şeklinde olmalı. Aldığını token'ı sağ üstteki authorize butonuna tıkladıktan sonra girebilirsiniz. Token expired olana kadar admin yetkileriyle uygulamayı kullanabilirsiniz. 

