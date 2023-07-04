# الگوهای طراحی در یونیتی

در این مخزن گیت، قصد دارم الگوهای طراحی مهم و پرکاربرد را به کمک مثال هایی در پروژه یونیتی توضیح دهم.

در این مخزن گیت، به بررسی الگوهای طراحی زیر می پردازیم:

+ Factory

+ Singleton

+ Builder

# الگوی طراحی Factory


# الگوی طراحی Singleton
این الگوی طراحی زمانی مورد استفاده قرار می گیرد که نیازمند آن هستیم که تنها یک instance از یک کلاس مشخص را در کل طول عمر برنامه داشته باشیم. حال شاید برایتان سوال ایجاد شود چرا بایستی از بعضی از کلاس ها تنها یک شی داشته باشیم، فرض کنید یک کلاس فایل یا دیتابیس داریم که از الگوی singleton پیروی نمی کند، دو تا برنامه نویس هر کدام جداگانه برای کد بخش خودشان روی برنامه اصلی یک instance از این کلاس ساخته و داده هایی که بایستی ذخیره شوند را به کمک این شی ها در سیستم ذخیره کنند. ممکن است این نحوه پیاده سازی باعث نقض سازگاری داده ها و ایجاد تفاوت در کاربران و اطلاعاتشان شود.
این الگوی طراحی همچنین به ما امکان دسترسی global به شی از کلاس singleton را از همه جای برنامه می دهد (علاوه بر این حقیقت که اجازه overwritten شدن  شی را می گیرد)
پیاده سازی این الگو دو گام دارد:

1. تغییر دسترسی constructor کلاس به private. این کار برای آن است که سایر کلاس ها نتوانند به صورت مستقیم و با کلید واژه new از کلاس مد نظر instance بگیرند.
2. ایجاد یک متد static که نقش constructor را ایفا کند به صورتی که کنترل کند همواره یک instance از شی در برنامه وجود داشته باشد و همواره آن instance را بازگرداند.
ساختار این الگو به صورت نمودار UML به صورت زیر می باشد:

![الگوی طراحی Singleton](https://www.dropbox.com/s/1r5yngb4att8xko/Singleton.png?dl=0)
در ادامه شبه کد این الگو طراحی آورده شده است:
1 // The Database class defines the `getInstance` method that lets
2 // clients access the same instance of a database connection
3 // throughout the program.
4 class Database is
5 // The field for storing the singleton instance should be
6 // declared static.
7 private static field instance: Database
8
9 // The singleton's constructor should always be private to
10 // prevent direct construction calls with the `new`
11 // operator.
12 private constructor Database() is
13 // Some initialization code, such as the actual
14 // connection to a database server.
15 // ...
16
17 // The static method that controls access to the singleton
18 // instance.
19 public static method getInstance() is
20 if (this.instance == null) then
21 acquireThreadLock() and then
22 // Ensure that the instance hasn't yet been
23 // initialized by another thread while this one
24 // has been waiting for the lock's release.
25 if (this.instance == null) then
26 this.instance = new Database()
27 return this.instance
28
29 // Finally, any singleton should define some business logic
30 // which can be executed on its instance.
31 public method query(sql) is
32 // For instance, all database queries of an app go
33 // through this method. Therefore, you can place
34 // throttling or caching logic here.
35 // ...
36
37 class Application is
38 method main() is
39 Database foo = Database.getInstance()
40 foo.query("SELECT ...")
41 // ...
42 Database bar = Database.getInstance()
43 bar.query("SELECT ...")
44 // The variable `bar` will contain the same object as
45 // the variable `foo`.



# الگوی طراحی Builder




