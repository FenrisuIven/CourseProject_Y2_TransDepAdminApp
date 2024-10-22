
<div style="text-align:justify">

![obviously not working preview image](https://github.com/FenrisuIven/CourseProject_Y2_TransDepAdminApp/blob/development/preview/preview_2422e29_22.png?raw=true)

<b>2422f29_23:</b> Small UI fixes, Truck Derived restrictions and validations, "Asynchronous" Truck and Driver addition when using AddTruck form, ChangePlace fix, ChangedDriver fix<br><br>
<b>2422e29_22:</b> MainWindow UI re-haul, Truck AssignedColor logic and handler of displaying colored profile image, Logic of displaying custom images that will allow to assign custom profile picture to each truck, Parking logic fixes and adjustments, Truck Availability change now triggers animations of departure and arrival, basic Task system assigns Truck Availability, DriverID to Truck and TruckID to Driver correctly, Fixes to AddTruck and AddDriver<br><br>
<b>2422d28_21:</b> Change to most of the events' signature, Adjustments to M-VM-V interactions, Fixes to ChangeParkingSpot logic<br><br>
<b>2422c28_20:</b> Fixes to NewTask validations, passing the validation to MainController and overall working with it. Currently not working due to some issue in cast and/or mapping of TDTO to T<br><br>
<b>2422b28_19:</b> Fix to DriverValidation, changes to AddNewTruck, Add new enum ActionType -- required changes being made to all the code that is for handling requests of actions with objects<br><br>
<b>2422a28_18:</b> Fix to NewDriver Category and Rating selection, Fix to Images source in project<br><br>
<b>2421c26_12:</b> Parking System re-written to MVVM, basic functionality restored<br><br>
<b>2421b26_11:</b> Backup for re-writing Parking System<br><br>
<b>2421a20_10:</b> Convert and adjust structure to fully implement MVVM Pattern. MainControllers and everything works, but serialization broke in the process. More clear folder structure.<br><br>
<b>2420a19_09:</b> Parking display system WIP, new trucks gets displayed on the parking grid. WIP for drive-out and drive-in animation. MainController and UI_Controller transferred to Singleton pattern. Fixes and adjustments to Add Truck logic, WIP logic for ParkingLot and Parking Places handling. Dev List-display windows that display all of the info, attached to each truck/driver instance. Profile-pics system WIP.<br><br>
<b>2419b10_08:</b> Truck data validation in AddNewTruck window, Transfer objects WIP, Truck addition partially works (only the "truck" side, new truck is present in main list and in ListBox), Object mapper works for all of the DTOs, Small Main Window UI refactor<br><br>
<b>2419a08_07:</b> DTO logic for classes, Serialization and Deserialization using System.Text.Json, ObjectMapper WIP, TruckList output stopped working (TBF)<br><br>
<b>2417d28_06:</b> Truck Addition Screen: basic layout, auto-filled title based on input Name of a truck, "Add New Driver" checkbox logic (blocking and enabling certain fields based on its state)<br><br>
<b>2417c25_05:</b> Folder structure refactor. Truck Addition Screen: auto filled-out name of a current truck that  gets created at the top of the screen.<br><br>
<b>2417b23_04:</b> Basic Screens logic and layout implementation. Small adjustments to UI Controller logic and UI Button Click handlers. Small fixes in Main Window Layout<br><br>
<b>2416a19_03:</b> Fixes and small adjustments to UI<br><br>
<b>2414a04_02:</b> Basic Task system implementation. Add new classes and their basic functionality: Driver, Task, Route, Cargo. Reformat folder structure 

---

<b>Застосунок адміністратора транспортного відділу підприємства</b></div>

---

<div style="text-align:justify">Графічний застосунок для відображення вільних від виконання перевезень вантажних автомобілів (грузова тентована, фура, рефрижератор ... -- 3-4 види вантажних авто) з відображенням їх на відповідних місцях паркування (у гаражі чи транспортному майданчику --  20-30 автомісць). Функції адміністратора - призначати задачу на перевезення користуючись інформацією про вантажопідйомність та тип авто. У додатку після призначення завдання має відображатись відїзд відповідного автомобіля з місця паркування.</div></div>

---
