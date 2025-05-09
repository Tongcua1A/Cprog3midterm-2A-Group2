# Cprog3Final-2A-Group2

04-28-2025
First Week Update to our project:
PLANING : FACULTY TIME IN, TIME OUT

Here's the basic plan: if papasok na sila sa work dapat mag Time in sila sa Isang system na ginawa natin pero simple lang yung visual like lalabas lang don is name tapos yung unique na code nila or yung password na binigay natin sa kanila bawat employee example ilalagay ko don sa system Rene Gallenero tas yung pass nila 31526 lalabas na don yung time na nag time in sila kunwari 8 am yung start nung work tapos matatapos 5pm so pag log in nila 8 am at umabot ng 5 pm yung work nila na di nag early time out edi yung sahod nila is complete 9 hours na work nila kunwari 100 per hour edi 900 na per day yon pag complete so kapag na delay sila one hour kunwari log in nila sa work is 9 am na so magiging 800 lang kahit aabot sila sa 5pm except nalang if mag overtime sila bawat overtime na Isang oras 100 pesos na sahod so kung aabutin man sipa ng 8 pm like start Sila 9 am or 8 am pero Sabihin natin Wala silang late pero mag overtime sila edi 1200 total of 12 hours kasama overtime nila simple lang yung time in time out para user friendly kasi yon naman main purpose non pero yung mas ma trabaho dito is yung sa data base mismo like dapat naka automatic set na yung time in time out, overtime,pati yung sahod, so if may bagong employee tayo gagawa ng passcode niya at tayo din maglalagay non sa data based like don yung magiging info niya


APRIL 30, 2025 (Updated features/plan)
FACULTY TIME IN TIME OUT 

✅ Final Feature Plan for “Faculty Time In / Time Out System”
1. 🔐 Login System
Purpose: Allow faculty to securely log in using name + password.

Features:

Faculty selects their name from a dropdown (to avoid typos).

Enters their password (set by admin).

If login is successful:

Redirect to their dashboard.

Log the time-in automatically (if it’s the first login of the day).

Store credentials securely (hash passwords if possible).

Optional: use ASP.NET Core Identity for real authentication & roles (Admin, Faculty).

2. 🧭 Faculty Dashboard
Purpose: Provide a simple and personalized workspace.

Features:

Welcome message (Hello, Remelyn Jhane Tongcua!)

Show today’s status:

✅ “You are timed in at 8:12 AM.”

❌ “You haven’t timed out yet.”

Time Out button (if already timed in).

Enter Overtime (optional): Allow faculty to manually input overtime hours after time-out.

Quick summary of today’s hours and computed salary.

Link to view attendance history.

3. ⏱️ Time In / Time Out System
Purpose: Log the exact time worked and handle salary deductions/bonuses.

Features:

On login, automatically record TimeIn if not yet logged in today.

On Time Out, system:

Saves TimeOut to database.

Calculates total hours worked.

Compares against standard 8:00 AM–5:00 PM.

Deduces hours late.

Adds overtime hours.

Calculates TotalSalary = (RegularHours + OvertimeHours) * HourlyRate.

Optional: block time-out if they haven’t timed in.

4. 📜 History Log Page
Purpose: Show full attendance and salary records.

Features:

Table view:

Date

Time In / Time Out

Regular Hours

Overtime

Total Salary

Filters:

By Date (e.g., this month, today, last 7 days)

Export to Excel or PDF (optional, bonus)

5. 🛠️ Admin Panel
Purpose: Manage faculty accounts and monitor activity.

Features:

Faculty List:

Add/Edit/Delete faculty

Reset password

Attendance Logs:

View all faculty logs

Search by name or date

Reports:

Total salary report per faculty

Summary of total hours worked

Optional:

Set work schedule (8:00 AM–5:00 PM default)

Customize hourly rate

📌 Bonus Ideas (Optional):
QR Code Time In: Future upgrade  scan ID to log time.

Notifications: Alert when faculty is late.

Audit Logs: Who changed what data (for admin logs).

Dark Mode UI option 😄


May 5, 2025(Update)
We are currently working on the login and registration pages of our website. We’re struggling with how to encrypt the password, but we are working together to find solutions to every bug we encounter. Remelyn (me) serves as the main coder of our group, while Kathy and Rene act as the bug fixers and sub-coders. Kenth serves as the group’s resource provider and helps with some syntax as well. 

