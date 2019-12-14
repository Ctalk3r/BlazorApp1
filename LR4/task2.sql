USE `student_schema`;
/* task 2. */;
 LOCK TABLES `country` WRITE;
insert into `country` values (1, 'Беларусь', 'BY'), (2, 'Россия', 'RU'), (3, 'Казахстан', 'KZ'), (4, 'Франция', 'FR'), (5, 'Великобритания', 'UK'), (6, 'Соединенные штаты Америки', 'USA'), (7, 'Испания', ' ES'), (8, 'Украина', 'UA'), (9, 'Узбекистан', 'UZ'), (10, 'Польша', 'PL');
unlock tables;
