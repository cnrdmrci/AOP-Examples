# Aspected Oriented Programming

### AOP nedir?
Aop(Aspected Oriented Programming); Kod içerisindeki karmaşıklığı azalmak ve SOLID'in Single responsibility kuralını uygulamaya yönelik, bir çok yerde yapılan ve tekrarlanan işlemlerin farklı modüllere ayrılmasıdır. Bu modüller sistemin birçok alanında kullanılmak üzere hazırlanır. Hazırlanan modüller ayrı bir bölüm olarak genel literatürde "Cross Cutting Concern" olarak adlandırılır. Cross Cutting Concern ile birlikte Aop tasarımı ortaya çıkmıştır.

Bu oluşturulan modüller fonksiyonel olmayan amaçlara yönelik kullanılmaktadır. Örnek olarak logging, caching, exception handling, security gibi işlemler olarak düşünülebilir.

Örnek tasarım aşağıdaki gibidir;
![CrossCuttingConcerns](https://user-images.githubusercontent.com/16361055/79202831-d71a7c80-7e42-11ea-91e0-635a24eff0ca.jpg)


### AOP Kullanım Yöntemleri

Aop için 2 çeşit kullanım yöntemi vardır.
- IL Weaving;\
 	Bu yöntem method çalışmadan öncesinde ve sonrasına müdahale ederek kodu direk çalıştırmaktadır. Diğer yönteme göre daha hızlı oluşmaktadır. Örnek kütüphaneler; PostSharp(Ücretli), KingAop(PostSharp'a alternatik open source kütüphane.).

- Method Interception;\
	Bu yöntem de aynı şekilde method çalışmadan öncesinde ve sonrasında müdahale ederek kodu reflection yardımıyla çalıştırmaktadır. IL Weaving yönteminden bu nedenle bir tık daha yavaş kalmaktadır. Ama abartılacak bir yavaşlığı bulunmamaktadır. Örnek Kütüphaneler; Castle Windsor, Autofac.

### Sonuç Olarak Aop'nin Faydaları

- Kod tekrarı önlenir ve birimler sadece kendi amacına yönelik kodları içerir.
- Kod karmaşası giderilir ve daha okunabilir kodlar içerir.
- Bakımı basitleştirir ve genişletilebilir mimari sunar.

