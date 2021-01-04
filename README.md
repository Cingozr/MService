Microservis çalışması için geliştirdğim projeyi çalıştırabilmek için öncelikle;
**Kurulum**
- Docker kurulumu yapmamız gerekmektedir. 1
[Docker Kurulum](https://www.docker.com/products/docker-desktop "Docker Kurulum")

- Docker kurulumunu tamamladıktan sonra mesajlasma servisi olarak kullandığım RabbitMq kurulumu yapmamız gerekmektedir. 
-  docker run -d --hostname rabbit_mastransit --name rabbit_example -p 8080:15672 -p 8081:5672 rabbitmq:3-management 
- RabbitMq kurmak için kullandığımız komut satırı kodunda port guncellemesi yapacak olursanız Servislere ait Api katmanında appsetting.json içerisinde 
```json
"RabbitMq": { "Hostname": "localhost", "Port": "8081", "QueueName": "ContactInformationQueue" } 
```

güncellemeyi unutmayın.

- Kurulumları tamamladıktan sonra servisleri çalıştırabilirsiniz.
