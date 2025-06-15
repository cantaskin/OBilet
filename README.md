# OBiletClone

OBiletClone, .NET 8 ile geliştirilmiş otobüs bileti rezervasyon sistemi.

---

## Kurulum ve Çalıştırma

1. **Projeyi klonlayın**

git clone https://github.com/cantaskin/OBilet.git

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


# Bus Management API Documentation

## Yeni Otobüs Oluşturma

Otobüs oluşturmak için gerekli alan bilgileri:

| Alan Adı | Tür | Açıklama |
|----------|-----|----------|
| `numberPlate` | string | Otobüsün plaka numarası. Örneğin: "34ABC123" |
| `hasOneSeat` | boolean | Otobüs tekli koltuk düzenine mi sahip? `true` ise evet. |
| `doorGapRowIndex` | integer | Kapı boşluğu hangi satırda yer alıyor? (örneğin: 3) |
| `doorGapSize` | integer | Kapı boşluğu kaç sıra yer kaplıyor? (örneğin: 1) |
| `column` | integer | Koltuk düzenindeki sütun sayısı (yan yana koltuk sayısı). |
| `row` | integer | Koltuk düzenindeki toplam satır sayısı. |
| `personelIds` | array of integers | Bu otobüse atanacak personel ID'leri. Birden fazla ID içerebilir. |

### ✅ Örnek Request:

```json
{
  "numberPlate": "34ABC123",
  "hasOneSeat": false,
  "doorGapRowIndex": 3,
  "doorGapSize": 1,
  "column": 4,
  "row": 10,
  "personelIds": [101, 102]
}
```

Bu örnek: 4 sütunlu, 10 satırlı, 3. sırada kapısı olan ve 2 personel atanmış bir otobüs tanımlar.

---

## Yeni Sefer Oluşturma

Otobüs seferi oluşturmak için gerekli alan bilgileri:

| Alan Adı | Tür | Açıklama |
|----------|-----|----------|
| `busId` | integer | Bu servise atanacak otobüsün ID'si. |
| `stationIds` | array of integers | Servisin uğrayacağı durakların ID listesi. Duraklar sıralı olmalıdır. |
| `startTime` | string (datetime) | Servisin başlama zamanı. ISO 8601 formatında (YYYY-MM-DDTHH:MM:SSZ). |
| `finishTime` | string (datetime) | Servisin bitiş zamanı. ISO 8601 formatında. |

### ✅ Örnek Request:

```json
{
  "busId": 12,
  "stationIds": [5, 9, 13],
  "startTime": "2025-06-16T08:00:00Z",
  "finishTime": "2025-06-16T12:30:00Z"
}
```

Bu örnek:
- ID: 12 olan otobüse ait
- 5 → 9 → 13 ID'li istasyonlara sırasıyla uğrayan
- Sabah 08:00'de başlayan ve öğlen 12:30'da biten bir otobüs servisidir

**⚠️ Önemli Not:** Şu andan en az bir saat sonrasına bir sefer oluşturulabilmektedir.

---

## Bilet Satın Alma

Bir kullanıcıya belirli bir otobüs seferinde koltuk rezerve etmek için kullanılır:

| Alan Adı | Tür | Açıklama |
|----------|-----|----------|
| `userId` | string (GUID) | Bileti alan kullanıcının benzersiz kimliği. |
| `busServiceId` | integer | Hangi otobüs servisine (sefer) bilet alındığını belirtir. |
| `seatId` | integer | Rezerve edilen koltuğun global ID'si. Lokal sıra/numara değil, sistemde benzersiz olarak tanımlanmış koltuk ID'si kullanılmalıdır. |
| `price` | number | Biletin ücreti (örneğin: 120.50). Fiyat para birimine göre değişebilir. |

### 🔍 Önemli Notlar:

- `seatId`, örneğin sadece "5 numaralı koltuk" değil; Seat entity'sinin veritabanındaki birincil anahtarıdır (örneğin: 4567 gibi).
- Bu yapı, çoklu koltuk seçimi desteklemiyor, sadece tek bilet (tek koltuk) için kullanılmalıdır.

### ✅ Örnek Request:

```json
{
  "userId": "a18f9cdd-6a00-4d4b-bf6d-14c3fbd264a3",
  "busServiceId": 25,
  "seatId": 4567,
  "price": 149.90
}
```

Bu örnek:
- Kullanıcı `a18f9cdd...` için
- 25 ID'li serviste
- 4567 ID'li (global) koltuk için
- 149.90 TL tutarında bilet oluşturur
