use [EmployeeDB];




go
alter procedure usp_Insert_Employee (
	@Name varchar(100),
	@Mobile bigint,
	@Email varchar(100),
	@DOB date,
	@Designation varchar(3)
) 
as
begin
	if object_id('Employees') is null
	begin
		create table Employees (
			ID int not null,
			Name varchar(100),
			Mobile bigint unique check (len(Mobile) = 10),
			Email varchar(100),
			DOB date,
			Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
		);
	end
	declare @id int;

		set @id = (select min(e1.ID) + 1
					  from Employees e1
					  where not exists (
						select 1
						from Employees e2
						where e2.ID = e1.ID + 1
					  ));
		if @id is null
		begin
			set @id = (select coalesce(max(ID), 0) + 1 from Employees)
		end	

	insert into Employees
	values
	(@id, @Name, @Mobile, @Email, @DOB, @Designation);
end;
go




go
alter procedure usp_Delete_Employee (
	@Name varchar(100)
)
as 
begin
	if exists (
		select *
		from Employees
		where Name = @Name
	)
	begin
		delete from Employees
		where Name = @Name
	end;
	else
	begin
		raiserror('Record doesn''t exist', 16, 1); 
	end
end;
go





go
alter procedure usp_Get_Employee (
	@Name varchar(100) = null
)
as
begin
	if object_id('Employees') is null
	begin
		create table Employees (
			ID int not null,
			Name varchar(100),
			Mobile bigint unique check (len(Mobile) = 10),
			Email varchar(100),
			DOB date,
			Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
		);
	end;

	if @Name is null 
	begin
		select * 
		from Employees
		order by 
		case
			when Designation = 'HO' then 1
			when Designation = 'RBM' then 2
			when Designation = 'CSM' then 3
			when Designation = 'CSE' then 4
		end, Name;
	end

	else if @Name is not null and not exists (select * from Employees where Name like '%'+ @Name +'%') or object_id('Employees') is null
	begin
		raiserror('Record doesn''t exist', 16, 1);
	end

	else
	begin
		select * 
		from Employees
		where Name like '%'+ @Name +'%'
		order by 
		case
			when Designation = 'HO' then 1
			when Designation = 'RBM' then 2
			when Designation = 'CSM' then 3
			when Designation = 'CSE' then 4
		end, Name; 
	end
end;
go


--go
--create procedure usp_Update_Employee (
--	@Field varchar(100),
--	@oldVal varchar(100),
--	@newVal varchar(100)
--)

--begin

--end


--go







select * from Employees

delete from Employees
where Name = 'Rajesh'

drop table Employees


exec usp_Insert_Employee 'Shreyas', 9820819314, 'shreyas@gmail.com', '2022-10-02', 'CSE';
exec usp_Insert_Employee 'Rajesh', 9820589316, 'rajesh@gmail.com', '2022-10-02', 'CSE';
exec usp_Insert_Employee 'Sandhya', 9222052650, 'sandhya@gmail.com', '2022-10-02', 'CSM';

exec usp_Delete_Employee 'Rajesh';
exec usp_Get_Employee;


exec usp_Insert_Employee 'John Doe', 9876543210, 'john@example.com', '1990-05-20', 'CSM';
exec usp_Insert_Employee 'Anuj', 1234567890, 'anuj@example.com', '2011-09-18', 'HO';




--declare @Field varchar(100) = 'Age',
--		@oldVal int = 22,
--		@newVal varchar(100) = 'Sandhya';

--DECLARE @SQL NVARCHAR(MAX);

--SET @SQL = N'
--UPDATE #Test
--SET ' + QUOTENAME(@Field) + N' = @newValue
--WHERE ' + QUOTENAME(@Field) + N' = @oldValue';

---- Execute the dynamic SQL with parameterized values
--EXEC sp_executesql @SQL, 
--                   N'@newValue VARCHAR(100), @oldValue VARCHAR(100)', 
--                   @newVal, @oldVal;



