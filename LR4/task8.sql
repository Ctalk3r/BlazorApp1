USE `student`;
/* task 8. */;

select house, flat, housing, post_index, home_phone_number, phone_number, email, house_postfix, flat_postfix from adress  limit 5;
select area_name from area  limit 5;
select country_name, county_alias from country  limit 5;
select district_name from district  limit 5;
select faculty_alias, faculty_name from faculty  limit 5;
select locality_name, locality_type from locality  limit 5;
select name1 from name1  limit 5;
select name2 from name2  limit 5;
select name3 from name3  limit 5;
select passport_iden_number, passport_number, passport_series, passport_location, gender, date_of_birth from passport  limit 5;
select speciality_alias, speciality_name from speciality  limit 5;
select street_name, street_type from street  limit 5;
select student_num, course, study_form_paying, study_form, 'group', admission_date, graduation_date, edit_date from student  limit 5;
select university_name, university_alias from university  limit 5;
