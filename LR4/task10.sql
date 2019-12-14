USE `student`;
/* task 10. */;

select  name1 as 'фамилия', name2 as 'имя', name3 as 'отчество',  
		country_name as 'страна', area_name as 'область', district_name as 'район', locality_type as 'тип населённого пункта', locality_name as 'название населенного пункта', 
        street_type as 'тип улицы', street_name as 'улица', house as 'номер дома', housing as 'корпус', flat as 'квартира' from student
inner join name1 on student.id_name1 = name1.id
inner join name2 on student.id_name2 = name2.id
inner join name3 on student.id_name3 = name3.id
inner join adress on student.id_adress = adress.id
inner join country on adress.id_country = country.id_country
inner join area on adress.id_area = area.id_area
inner join district on adress.id_district = district.id_district
inner join locality on adress.id_locality = locality.id_locality
inner join street on adress.id_street = street.id_street
