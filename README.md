# الگوهای طراحی در یونیتی

در این مخزن گیت، قصد دارم الگوهای طراحی مهم و پرکاربرد را به کمک مثال هایی در پروژه یونیتی توضیح دهم.

در این مخزن گیت، به بررسی الگوهای طراحی زیر می پردازیم:

+ Factory

+ Builder

+ Singleton

# الگوی طراحی Factory
فرض کنید کد یک برنامه را نوشته ایم که حمل و نقل جاده ای  را کنترل و مدیریت می کند. بعد از معروف شدن برنامه از شما درخواست شده قابلیت مدیریت حمل و نقل دریایی را هم به برنامه اضافه کنید. اگر به خوبی و بدون الگوی طراحی کد زده باشید با احتمال بالا نیاز پیدا می کنید که کد های زده شده قبلی خود را دستخوش تغییر کرده تا برنامه از حمل و نقل دریایی نیز پشتیبانی کند و این نقض اصل open/close از اصول SOLID می باشد.
در اینجا راه حل ارائه شده استفاده از الگوی طراحی factory می باشد. در این الگوی طراحی کار ساخت اشیا را از تولید مستقیم آن به کمک کلید واژه new به متد factory انتقال می دهیم. استفاده از این الگو در زمان هایی اتفاق میافتد که اطمینان و اطلاعات کاملی از نوع و وابستگی های تمامی اشیا نداشته و نمی دانیم در ادامه قرار است کلاسی جدید به برنامه برای ساخت اشیای جدید اضافه شود یا خیر.
یکی دیگر از کاربرد های این الگوی طراحی جلوگیری از هدر رفت منابع سیستمی می باشد. به عنوان مثال فرض کنید یک استخر ریسه (thread pool) شامل 10 تا thread داریم که میخواهیم تسک های ورودی را به ترتیب به همین ده thread داده و آنها را handle کنیم. این thread ها یک بار در ابتدای اجرای برنامه ایجاد شده و در حافظه نگه داری می شوند و هر بار که نیاز باشد به کمک متد factory یکی از thread های بیکار را گرفته و به آن کار نسبت می دهیم.
به تصویر زیر که نمایانگر ساختار این الگوی طراحی می باشد توجه کنید:

![توضیح تصویر](https://s8.uupload.ir/files/factory_sqeh.png)
در این الگو، یک کلاس سازنده پدر داریم که به ازای تک تک کلاس های مورد نیاز برای ساخت، یک زیرکلاس داریم که از این کلاس پدر ارثبری می کند. وظیفه ساخت اشیا بر عهده این زیرکلاس ها خواهد بود. با این ساختار در کد، هر موجودیت جدیدی که به برنامه اضافه شود، تنها کافی است یک کلاس factory مختص خود داشته باشد که از کلاس factory پدر ارث بری کرده و اقدام به ساخت شی از نوع موجودیت جدید می کند و هیچ تغییری در تکه کد های زده شده در بخش های قبلی ایجاد نخواهد شد (اصل open/close)

در ادامه شبه کد یک مثال از نحوه استفاده این الگوی طراحی آورده شده است. فرض کنید قصد پیاده سازی سیستمی را داریم که رابط کاربری پلتفرم های مختلف را قرار است ایجاد کند. 

![توضیح تصویر](https://s8.uupload.ir/files/factory2_3qcr.png)



# الگوی طراحی Builder

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
```
1 // Using the Builder pattern makes sense only when your products
2 // are quite complex and require extensive configuration. The
3 // following two products are related, although they don't have
4 // a common interface.
5 class Car is
6   // A car can have a GPS, trip computer and some number of
7   // seats. Different models of cars (sports car, SUV,
8   // cabriolet) might have different features installed or
9   // enabled.
10
11 class Manual is
12   // Each car should have a user manual that corresponds to
13   // the car's configuration and describes all its features.
14
15
16 // The builder interface specifies methods for creating the
17 // different parts of the product objects.
18 interface Builder is
19   method reset()
20   method setSeats(...)
21   method setEngine(...)
22   method setTripComputer(...)
23   method setGPS(...)
24
25 // The concrete builder classes follow the builder interface and
26 // provide specific implementations of the building steps. Your
27 // program may have several variations of builders, each
28 // implemented differently.
29 class CarBuilder implements Builder is
30   private field car:Car
31
32
33   // A fresh builder instance should contain a blank product
34   // object which it uses in further assembly.
35   constructor CarBuilder() is
36     this.reset()
37
38   // The reset method clears the object being built.
39   method reset() is
40    this.car = new Car()
41
42   // All production steps work with the same product instance.
43   method setSeats(...) is
44    // Set the number of seats in the car.
45
46   method setEngine(...) is
47    // Install a given engine.
48
49   method setTripComputer(...) is
50    // Install a trip computer.
51
52   method setGPS(...) is
53    // Install a global positioning system.
54
55   // Concrete builders are supposed to provide their own
56   // methods for retrieving results. That's because various
57   // types of builders may create entirely different products
58   // that don't all follow the same interface. Therefore such
59   // methods can't be declared in the builder interface (at
60   // least not in a statically-typed programming language).
61   //
62   // Usually, after returning the end result to the client, a
63   // builder instance is expected to be ready to start
64   // producing another product. That's why it's a usual
65   // practice to call the reset method at the end of the
66   // `getProduct` method body. However, this behavior isn't
67   // mandatory, and you can make your builder wait for an
68   // explicit reset call from the client code before disposing
69   // of the previous result.
70   method getProduct():Car is
71    product = this.car
72    this.reset()
73    return product
74
75 // Unlike other creational patterns, builder lets you construct
76 // unrelated products that don't follow a common interface.
77 class CarManualBuilder implements Builder is
78   private field manual:Manual
79
80   constructor CarManualBuilder() is
81    this.reset()
82
83   method reset() is
84    this.manual = new Manual()
85
86   method setSeats(...) is
87    // Document car seat features.
88
89   method setEngine(...) is
90    // Add engine instructions.
91
92   method setTripComputer(...) is
93    // Add trip computer instructions.
94
95   method setGPS(...) is
96    // Add GPS instructions.
97   method getProduct():Manual is
98    // Return the manual and reset the builder.
99
100
101 // The director is only responsible for executing the building
102 // steps in a particular sequence. It's helpful when producing
103 // products according to a specific order or configuration.
104 // Strictly speaking, the director class is optional, since the
105 // client can control builders directly.
106 class Director is
107   private field builder:Builder
108
109   // The director works with any builder instance that the
110   // client code passes to it. This way, the client code may
111   // alter the final type of the newly assembled product.
112   method setBuilder(builder:Builder)
113    this.builder = builder
114
115   // The director can construct several product variations
116   // using the same building steps.
117   method constructSportsCar(builder: Builder) is
118    builder.reset()
119    builder.setSeats(2)
120    builder.setEngine(new SportEngine())
121    builder.setTripComputer(true)
122    builder.setGPS(true)
123
124   method constructSUV(builder: Builder) is
125    // ...
126
127
128
129 // The client code creates a builder object, passes it to the
130 // director and then initiates the construction process. The end
131 // result is retrieved from the builder object.
132 class Application is
133
134   method makeCar() is
135    director = new Director()
136
137   CarBuilder builder = new CarBuilder()
138   director.constructSportsCar(builder)
139   Car car = builder.getProduct()
140
141   CarManualBuilder builder = new CarManualBuilder()
142   director.constructSportsCar(builder)
143
144   // The final product is often retrieved from a builder
145   // object since the director isn't aware of and not
146   // dependent on concrete builders and products.
147   Manual manual = builder.getProduct()
```


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

