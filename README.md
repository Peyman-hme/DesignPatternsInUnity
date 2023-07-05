# الگوهای طراحی در یونیتی

در این مخزن گیت، قصد دارم الگوهای طراحی مهم و پرکاربرد را به کمک مثال هایی در پروژه یونیتی توضیح دهم.

در این مخزن گیت، به بررسی الگوهای طراحی زیر می پردازیم:

+ Factory

+ Singleton

+ Builder

# الگوی طراحی Factory

الگوی طراحی builder به ما کمک می کند تا اشیای پیچیده و با صفات زیاد را گام به گام ایجاد کنیم. تصور کنید یک کلاس داریم که دارای 10 صفت می باشد. ولی اشیایی که از روی آن می خواهیم بسازیم برخی تنها 5 تا از این صفات را استفاده و مقدار دهی می کنند و  برخی دیگر 8 تا و سایر اشیا هر 10 تا را استفاده می کنند. یک شیوه پیاده سازی کد برای این نیازمندی استفاده از یک constructor با تعداد آرگومان 10 تاست که برای ساخت برخی اشیا تنها 5 تا از این آرگومان ها مقدار دهی می شوند و بقیه مقدار null می گیرند.

![توضیح تصویر](https://s8.uupload.ir/files/builder_om4k.png)

راه حل چنین سناریو هایی استفاده از الگو طراحی builder است. پیش تر گفتیم این الگو به صورت گام به گام شی مورد نظر ما را می سازد؛ به مثال زیر توجه کنید. فرض کنید قصد داریم انواع مختلفی خانه بسازیم. برخی از این خانه ها پنجره دارند، برخی گاراژ، تعداد در ها در خانه ها متفاوت است و موارد دیگر. برای ساخت خانه مورد نظر ابتدا دیوار ها را می سازیم(buildWalls)، سپس به آن سقف اضافه می کنیم(buildRoof)، چهار پنجره ((4)buildWindow) و یک گاراژ (buildGarage) و در (buildDoor) را نیز اضافه می کنیم و تمام، خانه ما آماده است، حال از خروجی کار بهره برداری می کنیم (getResult)

![توضیح تصویر](https://s8.uupload.ir/files/builder2_0kc7.png).

در این الگوی طراحی همچنین راهکاری وجود دارد برای ایجاد اشیایی که همگی گام های مشخصی را برای ساخته شدن طی می کنند. برای ساخت اینگونه اشیا می توان از director ها استفاده کرد. director کلاسی بوده که درون خود یک ارجاع به کلاس builder دارد و درون خود توابعی برای ایجاد انواع مختلف اشیا دارد که درون این توابع متد های builder با ترتیب و ورودی های خاصی صدا زده می شوند.
به تصویر زیر که ساختار این الگوی طراحی را نشان میدهد توجه کنید:

![توضیح تصویر](https://s8.uupload.ir/files/builder3_16yd.png)

در اینجا ما یک رابط builder تعریف کرده ایم که دو کلاس builder دیگر ما آن را پیاده سازی کرده اند. این دو کلاس هر کدام شی ای متفاوت  از هم را قرار است تولید کنند (Product1,Product2) گام ها و متدهای این کلاس های سازنده در UML قابل مشاهده است.
به ساختار درونی کلاس Director توجه کنید، در این کلاس متد make با توجه به ورودی خود اقدام به پیشبرد روند ساخت شی بر اساس ترتیب از قبل مشخص شده گام های ساخت شی میکند. برای مثال، اگر نوع ورودی تابع make از نوع simple باشد، تنها گام A را انجام داده و خروجی مطلوب را آماده می کند، اما اگر ورودی از نوع simple نبود، ابتدا گام B و سپس گام Z را برای ساخت شی و نسبت دادن ویژگی ها به آن را طی می کند.

در ادامه شبه کدی با این الگوی طراحی آورده شده است:



# الگوی طراحی Singleton

این الگوی طراحی زمانی مورد استفاده قرار می گیرد که نیازمند آن هستیم که تنها یک instance از یک کلاس مشخص را در کل طول عمر برنامه داشته باشیم. حال شاید برایتان سوال ایجاد شود چرا بایستی از بعضی از کلاس ها تنها یک شی داشته باشیم، فرض کنید یک کلاس فایل یا دیتابیس داریم که از الگوی singleton پیروی نمی کند، دو تا برنامه نویس هر کدام جداگانه برای کد بخش خودشان روی برنامه اصلی یک instance از این کلاس ساخته و داده هایی که بایستی ذخیره شوند را به کمک این شی ها در سیستم ذخیره کنند. ممکن است این نحوه پیاده سازی باعث نقض سازگاری داده ها و ایجاد تفاوت در کاربران و اطلاعاتشان شود.

این الگوی طراحی همچنین به ما امکان دسترسی global به شی از کلاس singleton را از همه جای برنامه می دهد (علاوه بر این حقیقت که اجازه overwritten شدن  شی را می گیرد)

پیاده سازی این الگو دو گام دارد:

 ابتدا تغییر دسترسی constructor کلاس به private. این کار برای آن است که سایر کلاس ها نتوانند به صورت مستقیم و با کلید واژه new از کلاس مد نظر instance بگیرند.

 سپس ایجاد یک متد static که نقش constructor را ایفا کند به صورتی که کنترل کند همواره یک instance از شی در برنامه وجود داشته باشد و همواره آن instance را بازگرداند.

ساختار این الگو به صورت نمودار UML به صورت زیر می باشد:
![الگو طراحی Singleton](https://s8.uupload.ir/files/singleton_b7qf.png)

شبه کدی از این الگو طراحی در ادامه آورده شده است:
```
1   // The Database class defines the `getInstance` method that lets
2   // clients access the same instance of a database connection
3   // throughout the program.
4   class Database is
5   // The field for storing the singleton instance should be
6   // declared static.
7   private static field instance: Database
8
9   // The singleton's constructor should always be private to
10   // prevent direct construction calls with the `new`
11   // operator.
12   private constructor Database() is
13   // Some initialization code, such as the actual
14   // connection to a database server.
15   // ...
16
17   // The static method that controls access to the singleton
18   // instance.
19   public static method getInstance() is
20       if (this.instance == null) then
21         acquireThreadLock() and then
22       // Ensure that the instance hasn't yet been
23       // initialized by another thread while this one
24       // has been waiting for the lock's release.
25       if (this.instance == null) then
26         this.instance = new Database()
27       return this.instance
28
29   // Finally, any singleton should define some business logic
30   // which can be executed on its instance.
31   public method query(sql) is
32     // For instance, all database queries of an app go
33     // through this method. Therefore, you can place
34     // throttling or caching logic here.
35     // ...
36
37   class Application is
38     method main() is
39       Database foo = Database.getInstance()
40       foo.query("SELECT ...")
41       // ...
42       Database bar = Database.getInstance()
43       bar.query("SELECT ...")
44       // The variable `bar` will contain the same object as
45       // the variable `foo`.
```

