The solution can be opened in Visual Studio buy opening todolist_UI.sln from the Folder.

Steps to run the application.
------------------------------
1. The project uses a todolist table in mysql database. Create the table using :

	CREATE TABLE `todoitems` (
  `id` int NOT NULL AUTO_INCREMENT,
  `taskname` varchar(100) DEFAULT NULL,
  `status` varchar(15) NOT NULL DEFAULT 'PENDING',
  `duedate` varchar(15) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `todoitems_chk_1` CHECK ((`status` in ('PENDING','DONE')))
);

2. Update the Connection string in appsettings.json.

3. Configure the visual studio to run with multiple statup projects. This can be done by the properties of the main solution. (Properties -> Common Properties -> Startup Project   --- select Multiple startup projects)

4. Click Start.


How to use the application
----------------------------
The default landing page shows the list of tasks created.
Click on Add New Task button to create task.

The tasks created will appear back in the listing. From the row click on :
	Edit - To view and edit the task.
	Delete - To delete the task
	Finished - To mark the task as DONE.
	
Note: Make sure to set the date later than current date for creating or editing the task (The validation response message are incomplete. It will show only "Unable to create the task").

Validations
-----------
1. The date selected should be later than current date while creating or editing the task.
2. The combination for task name and due date should be unique.

