USE `student`;
/* task 7. */;

select house, flat, housing, post_index, home_phone_number, phone_number, email,house_postfix, flat_postfix from adress;
select area_name from area;
select country_name, county_alias from country;
select district_name from district;
select faculty_alias, faculty_name from faculty;
select locality_name, locality_type from locality;
select name1 from name1;
select name2 from name2;
select name3 from name3;
select passport_iden_number, passport_number, passport_series, passport_location, gender, date_of_birth from passport;
select speciality_alias, speciality_name from speciality;
select street_name, street_type from street;
select student_num, course, study_form_paying, study_form, 'group', admission_date, graduation_date, edit_date from student;
select university_name, university_alias from university;
