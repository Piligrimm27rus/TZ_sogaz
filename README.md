# TZ_sogaz

# Описание
Антиспам бот. Удаляет всё кроме текста входящим в чат пользователям. После 3-х сообщений ограничения снимаются.
Добавь в чат, если новые пользователи кидают рекламу. @tz_sogaz_bot 

# Технологии
Бот сделан на языке c# с использованием Web API.
Запросы принимаются с использованием метода webhook.
Программа работает с поддержкой docker.
Образ хостится на сервисе Heroku.

# Deploy
Для того чтобы проект хостился, необходимо зарегистрироваться на сервисе Heroku. 
Далее в консоли
```
heroku container:login 
docker build -t tz-sogaz C:\Users\***\source\repos\TZ_sogaz\TZ_sogaz\bin\Release\net5.0\publish)
docker tag tz-sogaz registry.heroku.com/tz-sogaz/web
docker push registry.heroku.com/tz-sogaz/web
heroku cantainer:release web --app tz-sogaz
```
