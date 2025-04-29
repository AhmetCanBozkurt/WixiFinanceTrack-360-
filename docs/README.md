WixiFinanceTrack 360 - Finansal Takip Uygulaması PRD (Product Requirements Document)
✨ Genel Bilgiler
•	Proje Adı: WixiFinanceTrack 360
•	Amaç: Kullanıcıların gelir, gider ve yatırımlarını takip edebilecekleri, detaylı bir finansal kontrol uygulaması sağlamak
•	Platformlar:
o	Backend: ASP.NET Core Web API
o	Frontend Web: React.js
o	Mobil: React Native
•	Kimlik Doğrulama: JWT Token + Refresh Token
•	Veritabanı: Microsoft SQL Server
•	Deployment: IIS veya Docker Service
________________________________________
🔎 Ana Modüller
1. Kullanıcı Yönetimi
•	Kaydolma, giriş, şifre yenileme
•	Profil ve tercih ayarları
•	JWT tabanlı güvenli kimlik doğrulama
2. Gelir & Gider Takibi
•	Tek seferlik ve taksitli gelir/gider kayıtları
•	Giderlerin kategori bazlı takibi
•	Taksitli giderler için:
o	Başlangıç tarihi, toplam taksit sayısı
o	Her aya otomatik taksit dağıtımı
o	Aylık taksit görüntüleme ve durum güncelleme
3. Raporlama
•	Aylık ve yıllık gelir-gider grafik ve tabloları
•	Kategori bazlı harcama analizi
•	Toplam borç, alacak, tasarruf istatistikleri
4. Bildirim Sistemi
•	Aylık finansal özet maili
•	Gider limit uyarıları
•	Taksit ödeme hatırlatmaları
5. Ayarlar
•	Para birimi, dil, tema ayarları
•	Kendi kategorilerini oluşturma
•	Cihaz bildirimi (mobil)
6. Yatırım Takip Modülü
•	Kullanıcının yatırım girişi yapabileceği sistem
•	Desteklenen yatırım türleri:
o	Altın (gram altın)
o	Döviz (USD, EUR, vb.)
o	Hisse Senetleri (Borsa verisi)
•	Her yatırım için:
o	Alım tarihi, miktar, alım fiyatu
o	Gerçek zamanlı piyasa verisi entegrasyonu (dış API ile)
o	Anlık kâr/zarar hesaplaması
o	Portföy bazlı getiri raporları
________________________________________
📊 Veritabanı Özeti
Users
Id, Name, Email, PasswordHash, CreatedAt, UpdatedAt
Transactions
Id, UserId, Type (Income/Expense), Amount, Currency, CategoryId, Date, IsInstallment, InstallmentCount, InstallmentNumber, Note
Categories
Id, UserId, Name, Type, IsDefault
InstallmentPlans
Id, TransactionId, UserId, StartDate, Count, MonthlyAmount
InstallmentDetails
Id, InstallmentPlanId, Month, Year, DueDate, Amount, PaidStatus
Investments
Id, UserId, Type (Gold/USD/Stock), AssetCode (XAU/USD/ISCTR.IS), PurchaseDate, Quantity, PurchasePrice, Notes
InvestmentValues (cache tablosu)
Id, AssetCode, Date, Price, Source
________________________________________
🔊 API Uç Noktaları (REST)
/api/auth
•	POST /register
•	POST /login
•	POST /refresh
/api/Hareketler
•	GET /
•	POST / (Taksitli destekli)
•	GET /
/api/giderler
•	GET /
•	POST /pay
•	GET /{id}
•	DELETE /{id}
/api/gelirler
•	GET /
•	POST /
•	GET /{id}
•	DELETE /{id}
/api/marketdata (cache veya webhook destekli)
•	GET /gold
•	GET /currency?code=USD
•	GET /stock?symbol=ISCTR.IS
________________________________________
📕 Sprint Planı (6 Sprint)
Sprint	Hedef
1	JWT auth, kullanıcı ve kategori CRUD
2	Gelir/Gider CRUD, taksitli gider mantığı
3	Raporlama modülü
4	Yatırım modülü + API entegrasyonu
5	Web & Mobil UI geliştirme
6	Bildirimler + yayınlama + test
________________________________________
📢 Notlar
•	Swagger dokümanlama
•	EF Core ile migration sistemi
•	Unit test: xUnit & Moq
•	Background Service ile yatırım verisi cache güncelleme
•	Dış API: Altın/döviz için TCMB, hisse için Finnhub veya Yahoo Finance
________________________________________

