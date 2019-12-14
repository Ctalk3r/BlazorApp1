USE `student`;
/* task 9. */;

select  name1 as 'фамилия', name2 as 'имя', name3 as 'отчество', 
		university_name as 'университет', faculty_name as 'факультет', speciality_name as 'специальность' from student
inner join name1 on student.id_name1 = name1.id
inner join name2 on student.id_name2 = name2.id
inner join name3 on student.id_name3 = name3.id
inner join university on student.id_university = university.id
inner join faculty on student.id_faculty = faculty.id
inner join speciality on student.id_speciality = speciality.id;
