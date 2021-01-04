# MService
Microservis çalışması için geliştirdğim projeyi çalıştırabilmek için öncelikle;
Kurulum
-------
1- Docker kurulumu yapmamız gerekmektedir.
1.1: Docker: https://www.docker.com/products/docker-desktop
2. Docker kurulumunu tamamladıktan sonra mesajlasma servisi olarak kullandığım RabbitMq kurulumu yapmamız gerekmektedir.
2.2: docker run -d --hostname rabbit_mastransit --name rabbit_example -p 8080:15672 -p 8081:5672 rabbitmq:3-management
2.2.1: RabbitMq kurmak için kullandığımız komut satırı kodunda port guncellemesi yapacak olursanız Servislere ait Api katmanında appsetting.json içerisinde 
   "RabbitMq": {
      "Hostname": "localhost",
      "Port": "8081",
      "QueueName": "ContactInformationQueue"
    } 
    güncelleme yapmayı unutmayın.
    
3. Kurulumları tamamladıktan sonra  servisleri çalıştırabilirsiniz.



