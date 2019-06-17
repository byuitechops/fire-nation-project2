# Canvas Module Getter Project
This project is going to expand your knowledge on C# by making an API call to get a courses modules and generating three types of reports to display the data. With the previous learning activity under your belt, you have had practice consuming data from an `API GET` response and storing that data. 

## Project Desription

### Learning and Prep
To help you further your growth in the world of C# and Object Oriented Programming, learn about the following:
 - [ ] Have an understanding about Interfaces
 - [ ] Understand how to use Inheritance
 - [ ] Generics in C#
 - [ ] Learn about Dependency Injection
 - [ ] Testing 
   - [ ] Unit Testing
   - [ ] E2E (End-to-End) Testing 
- [ ] Have an understanding about the S.O.L.I.D design principles
- [ ] Have an understanding about Clean Architechture
- [ ] Breifly review and install [BootStrap](https://getbootstrap.com/)
 
### Project Insturctions
With dependency injection in mind, make and authented `GET` request to Canvas to get a list of courses modules and their module items. With the response from the `GET` request, generate a report to show the data. The report could be a CSV file, JSON file, or a HTML file. The user will be able to choose their desired output report. As far as the HTML report goes, don't spend lots of time designing and styling a fancy website to hold a data. Please do make it look good however, using elements from BootStrap. With HTML in mind, please also don't create external styling sheets or script files, the report should be ONE HTML file that Josh can email and the end user can open it right up to see. When designing how to make an HTML report you can experiment with HTML templating, concatenation, or even string interpolation. Additionaly, add testing to your project. Make sure you include unit testing as well as (E2E) End-to-End testing.

### Review of instructions 
- [ ] Make a `GET` Request to Canvas to get a list of courses modules and their module items.
- [ ] Generate one of three reports of the data
  - [ ] A CSV of the modules items
  - [ ] A JSON file of the modules and module items
  - [ ] An HTML file displaying the modules and their items, with nice styling
- [ ] Have unit testing as well as E2E (End-to-End) testing


## What to include in the reports
Below are some examples of how a report can look

### CSV
*Please note that URL's and ID's are hidden in this example, your program will include them. 
``` csv 
CourseID,ModName,Name,ID,Url,Type,Published,ModuleID
{CourseID HIDDEN},Welcome,Syllabus,{ID HIDDEN},{URL HIDDEN},Page,True,{ModuleID HIDDEN}
{CourseID HIDDEN},Welcome,University Policies,{ID HIDDEN},{URL HIDDEN},ExternalUrl,True,{ModuleID HIDDEN}
{CourseID HIDDEN},Welcome,Questions and Conversations,{ID HIDDEN},{URL HIDDEN},Discussion,True,{ModuleID HIDDEN}
{CourseID HIDDEN},Welcome,Online Support Center,{ID HIDDEN},{URL HIDDEN},ExternalUrl,True,{ModuleID HIDDEN}
{CourseID HIDDEN},Welcome,Link Test,{ID HIDDEN},{URL HIDDEN},Page,True,{ModuleID HIDDEN}
```

### JSON
*Please note that URL's and ID's are hidden in this example, your program will include them. 
``` JSON
{
    "courseID": "{HIDDEN}",
    "modules": [
        {
            "name": "Welcome",
            "items": [
                {
                    "CourseID": "{HIDDEN}",
                    "ModName": "Welcome",
                    "Name": "Syllabus",
                    "ID": "{HIDDEN}",
                    "Url": "{HIDDEN}",
                    "Type": "Page",
                    "Published": "True",
                    "ModuleID": "{HIDDEN}"
                },
                {
                    "CourseID": "{HIDDEN}",
                    "ModName": "Welcome",
                    "Name": "University Policies",
                    "ID": "{HIDDEN}",
                    "Url": "{HIDDEN}",
                    "Type": "ExternalUrl",
                    "Published": "True",
                    "ModuleID": "{HIDDEN}"
                }, ...
            ]
        }, ...
    ]
}
```

### HTML 
For this report, be creative on how you would like it to look. Use BootStrap to style your page. However, don't spend ample amounts of time on this. Display the information in a clear, easy to read manner. When displaying the data, include links to the module items, as well as if they are published or not.