USE `student_schema`;
/* task 4. */;
insert into `district` values (1, 'Минский'), (2, 'Слуцкий'), (3, 'Логойский'), (4, 'Несвижский'), (5, 'Дзержинский'), (6, 'Вилейский'), (7, 'Копыльский'), (8, 'Слонимский'), (9, 'Лидский'), (10, 'Волковысский');

insert into `area` values (1, 'Брестская'), (2, 'Витебская'), (3, 'Гомельская'), (4, 'Гродненская'), (5, 'Минская'), (6, 'Могилевский'), (7, 'Амурская'), (8, 'Владимирская'), (9, 'Иркутская'), (10, 'Калужская');

insert into `faculty` values (1, 'ФКСиС', 'Факультет компьютерных систем и сетей'), (2, 'ФИК', 'Факультет инфокоммуникаций'), (3, 'ФРЭ', 'Факультет радиотехники и электроники'), (4, 'ФКП', 'Факультет компьютерного проектирования'), (5, 'ФИНО', 'Факультет иновационного непрерывного образования'), (6, 'ВФ', 'Военный факультет'), (7, 'ИИТ', 'Институт информационных технологий'), (8, 'ФИТУ', 'Факультет информационных технологий и управления'), (9, 'ФТК', 'Факультет телекоммуникаций'), (10, 'ФММ', 'Факультет математического моделирования');
insert into `speciality` values (1, ' ИиТП', 'Информатика и технологии программирования'), (2, 'ПОИТ', 'Программное обеспечение информационных технологий'), (3, 'ВМСиС', 'Вычислительные машины, системы и сети'), (4, 'ЭВС', 'Электронные вычислительные средства'), (5, 'ИИ', 'Искусственный интеллект'), (6, 'ИТиУвТС', 'Информационные технологии и управление в технических системах'), (7, 'ПЭ', 'Промышленная электроника'), (8, 'АСОИ', 'Автоматизированные системы обработки информации'), (9, 'МЭ', 'Медицинская электроника'), (10, 'ЭСБ', 'Электронные системы безопасности');
insert into `university` values (1, ' Белорусский государственный университет информатики и радиоэлектроники', 'БГУИР'), (2, 'Белорусский государственный университет', 'БГУ'), (3, 'Московский физико-технический институт', 'МФТИ'), (4, 'Белорусский государственный медицинский университет', 'БГМУ'), (5, 'Белорусский национальный технический университет', 'БНТУ'), (6, 'Белорусский государственный экономический университет', 'БГЭУ'), (7, 'Белорусский государственный технологический университет', 'БГТУ'), (8, 'Белорусский государственный университет культуры и искусств', 'БГУКИ'), (9, 'Белорусский государственный университет транспорта', 'БГУТ'), (10, 'Белорусская государственная академия связи', 'БГАС');
