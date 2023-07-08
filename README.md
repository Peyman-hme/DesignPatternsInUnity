# الگوهای طراحی در یونیتی

در این مخزن گیت، قصد دارم الگوهای طراحی مهم و پرکاربرد را به کمک مثال هایی در پروژه یونیتی توضیح دهم.

در این مخزن گیت، به بررسی الگوهای طراحی زیر می پردازیم:

+ [Factory](#الگوی-طراحی-factory)

+ [Builder](#الگوی-طراحی-builder)

+ [Singleton](#الگوی-طراحی-singleton)

+ [Adapter](#الگوی-طراحی-adapter)

+ [Flyweight](#الگوی-طراحی-flyweight)

# الگوی طراحی Factory
فرض کنید کد یک برنامه را نوشته ایم که حمل و نقل جاده ای  را کنترل و مدیریت می کند. بعد از معروف شدن برنامه از شما درخواست شده قابلیت مدیریت حمل و نقل دریایی را هم به برنامه اضافه کنید. اگر به خوبی و بدون الگوی طراحی کد زده باشید با احتمال بالا نیاز پیدا می کنید که کد های زده شده قبلی خود را دستخوش تغییر کرده تا برنامه از حمل و نقل دریایی نیز پشتیبانی کند و این نقض اصل open/close از اصول SOLID می باشد.
در اینجا راه حل ارائه شده استفاده از الگوی طراحی factory می باشد. در این الگوی طراحی کار ساخت اشیا را از تولید مستقیم آن به کمک کلید واژه new به متد factory انتقال می دهیم. استفاده از این الگو در زمان هایی اتفاق میافتد که اطمینان و اطلاعات کاملی از نوع و وابستگی های تمامی اشیا نداشته و نمی دانیم در ادامه قرار است کلاسی جدید به برنامه برای ساخت اشیای جدید اضافه شود یا خیر.
یکی دیگر از کاربرد های این الگوی طراحی جلوگیری از هدر رفت منابع سیستمی می باشد. به عنوان مثال فرض کنید یک استخر ریسه (thread pool) شامل 10 تا thread داریم که میخواهیم تسک های ورودی را به ترتیب به همین ده thread داده و آنها را handle کنیم. این thread ها یک بار در ابتدای اجرای برنامه ایجاد شده و در حافظه نگه داری می شوند و هر بار که نیاز باشد به کمک متد factory یکی از thread های بیکار را گرفته و به آن کار نسبت می دهیم.
به تصویر زیر که نمایانگر ساختار این الگوی طراحی می باشد توجه کنید:

![توضیح تصویر](https://s8.uupload.ir/files/factory_sqeh.png)
در این الگو، یک کلاس سازنده پدر داریم که به ازای تک تک کلاس های مورد نیاز برای ساخت، یک زیرکلاس داریم که از این کلاس پدر ارثبری می کند. وظیفه ساخت اشیا بر عهده این زیرکلاس ها خواهد بود. با این ساختار در کد، هر موجودیت جدیدی که به برنامه اضافه شود، تنها کافی است یک کلاس factory مختص خود داشته باشد که از کلاس factory پدر ارث بری کرده و اقدام به ساخت شی از نوع موجودیت جدید می کند و هیچ تغییری در تکه کد های زده شده در بخش های قبلی ایجاد نخواهد شد (اصل open/close)

در ادامه شبه کد یک مثال از نحوه استفاده این الگوی طراحی آورده شده است. فرض کنید قصد پیاده سازی سیستمی را داریم که رابط کاربری پلتفرم های مختلف را قرار است ایجاد کند. 

![توضیح تصویر](https://s8.uupload.ir/files/factory2_3qcr.png)

```
1 // The creator class declares the factory method that must
2 // return an object of a product class. The creator's subclasses
3 // usually provide the implementation of this method.
4 class Dialog is
5   // The creator may also provide some default implementation
6   // of the factory method.
7   abstract method createButton()
8
9   // Note that, despite its name, the creator's primary
10   // responsibility isn't creating products. It usually
11   // contains some core business logic that relies on product
12   // objects returned by the factory method. Subclasses can
13   // indirectly change that business logic by overriding the
14   // factory method and returning a different type of product
15   // from it.
16   method render() is
17    // Call the factory method to create a product object.
18    Button okButton = createButton()
19    // Now use the product.
20    okButton.onClick(closeDialog)
21    okButton.render()
22
23
24 // Concrete creators override the factory method to change the
25 // resulting product's type.
26 class WindowsDialog extends Dialog is
27   method createButton() is
28    return new WindowsButton()
29
30 class WebDialog extends Dialog is
31   method createButton() is
32    return new HTMLButton()
33
34
35 // The product interface declares the operations that all
36 // concrete products must implement.
37 interface Button is
38   method render()
39   method onClick(f)
40
41 // Concrete products provide various implementations of the
42 // product interface.
43 class WindowsButton implements Button is
44   method render(a, b) is
45    // Render a button in Windows style.
46   method onClick(f) is
47    // Bind a native OS click event.
48
49 class HTMLButton implements Button is
50   method render(a, b) is
51    // Return an HTML representation of a button.
52   method onClick(f) is
53    // Bind a web browser click event.
54
55
56 class Application is
57   field dialog: Dialog
58
59   // The application picks a creator's type depending on the
60   // current configuration or environment settings.
61   method initialize() is
62    config = readApplicationConfigFile()
63
64    if (config.OS == "Windows") then
65     dialog = new WindowsDialog()
66    else if (config.OS == "Web") then
67     dialog = new WebDialog()
68    else
69     throw new Exception("Error! Unknown operating system.")
70
71   // The client code works with an instance of a concrete
72   // creator, albeit through its base interface. As long as
73   // the client keeps working with the creator via the base
74   // interface, you can pass it any creator's subclass.
75   method main() is
76    this.initialize()
77    dialog.render()
```

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
# الگوی طراحی Adapter
![image](https://github.com/Peyman-hme/DesignPatternsInUnity/assets/62210041/7f83f639-23b9-4a16-8918-bb81185b2284)


فرض کنید یک برنامه دارید که با فایل های xml کار میکند. حال قصد دارید یک سیستم تحلیل آماری که از قبل کد زده اید را به این برنامه خود اضافه کنید اما مشکلی که هست این است که این سیستم تحلیل آماری شما با فایل های json کار می کند و نمیتواند محتوای فایل های xml را بخواند. در این گونه سناریو ها الگوی طراحی adapter استفاده میشود. این الگوی طراحی با کمک wrap کردن شی سرویس دهنده به صورتی که شی گیرنده دیدی نسبت به این wrap شدن نداشته باشد و به کمک واسطی سرویس خود را دریافت کند، کار تبدیل رابط هایی که با یک دیگر سازگاری ندارد را انجام میدهد.
این الگو به دو روش پیاده سازی می شود. شیوه اول آن است که adapter ما، یک instance از کلاس سرویس دهنده را درون خود دارد و به اصطلاح wrap می کند. سپس رابط کلاینت را پیاده سازی کرده و تمامی متد های آن را بازنویسی کرده تا سرویس دهنده بتواند با فرمت رابط خود از داده های کلاینت استفاده کند. شکل زیر ساختار این روش پیاده سازی را نشان می دهد:
![image](https://github.com/Peyman-hme/DesignPatternsInUnity/assets/62210041/434ebc97-8c49-4c25-ab21-fc6c7ae05d99)

شیوه دوم پیاده سازی این الگو آن است که کلاس adapter ما از هر دو کلاس سرویس دهنده و کلاینت ارث بری کرده و متد های آنها را بازنویسی می کند. در این شیوه دیگر نیاز به wrap کردن سرویس دهنده نیست. شکل ساختار این نحوه پیاده سازی را در تصویر زیر مشاهده می کند:
![image](https://github.com/Peyman-hme/DesignPatternsInUnity/assets/62210041/eaee8a40-154c-4803-b02c-6fb6d5ea3f33)

در ادامه یک شبه کد از پیاده سازی این الگو آورده شده است:

'''
1 // Say you have two classes with compatible interfaces:
2 // RoundHole and RoundPeg.
3 class RoundHole is
4   constructor RoundHole(radius) { ... }
5
6   method getRadius() is
7    // Return the radius of the hole.
8
9   method fits(peg: RoundPeg) is
10    return this.getRadius() >= peg.radius()
11
12 class RoundPeg is
13   constructor RoundPeg(radius) { ... }
14
15   method getRadius() is
16    // Return the radius of the peg.
17
18
19 // But there's an incompatible class: SquarePeg.
20 class SquarePeg is
21   constructor SquarePeg(width) { ... }
22
23   method getWidth() is
24    // Return the square peg width.
25
26
27 // An adapter class lets you fit square pegs into round holes.
28 // It extends the RoundPeg class to let the adapter objects act
29 // as round pegs.
30 class SquarePegAdapter extends RoundPeg is
31   // In reality, the adapter contains an instance of the
32   // SquarePeg class.
33   private field peg: SquarePeg
34
35   constructor SquarePegAdapter(peg: SquarePeg) is
36    this.peg = peg
37
38   method getRadius() is
39    // The adapter pretends that it's a round peg with a
40    // radius that could fit the square peg that the adapter
41    // actually wraps.
42    return peg.getWidth() * Math.sqrt(2) / 2
43
44
45 // Somewhere in client code.
46 hole = new RoundHole(5)
47 rpeg = new RoundPeg(5)
48 hole.fits(rpeg) // true
49
50 small_sqpeg = new SquarePeg(5)
51 large_sqpeg = new SquarePeg(10)
52 hole.fits(small_sqpeg) // this won't compile (incompatible types)
53
54 small_sqpeg_adapter = new SquarePegAdapter(small_sqpeg)
55 large_sqpeg_adapter = new SquarePegAdapter(large_sqpeg)
56 hole.fits(small_sqpeg_adapter) // true
57 hole.fits(large_sqpeg_adapter) // false
'''

# الگوی طراحی Flyweight
تصور کنید یک بازی طراحی کرده اید که در آن سربازان تیراندازی می کنند و پس از گذشت 30 ثانیه تعداد گلوله ها به یک میلیون می رسد و برنامه کرش می کند زیرا ram  از آبجکت های گلوله پر شده است. این آبجکت های گلوله دارای تعدادی صفت مشترک اند مانند رنگ و شکل گلوله، حال فرض کنید به تعداد یک میلیون تا از این صفات تکراری در ram وجود دارد! بایستی بدنبال راه حلی باشیم تا بتوان ویژگی های مشترک این گلوله ها را تنها یک بار در ram نگه داشته و تمامی یک میلیون آبجکت از همان یک موجودیت مشترکا استفاده کنند. الگوی طراحی flyweight دقیقا همین راه حل را دنبال می کند. 

در این الگو صفات به دو دسته تقسیم می شوند:
+ صفاتی که برای تمامی اشیا مقداری یکسان دارد و تکراری است. این صفات را intrinsic می نامیم
+ صفاتی که برای هر شی مقداری یکتا دارد و بایستی به ازای تک تک این صفات مقداری را در ram نگهداری کرد. به این صفات extrinsic می گوییم
این الگوی طراحی صفات intrinsic و extrinsic را از هم جدا کرده و در دو کلاس متفاوت نگهداری می کند. با اینکار، میتواند به تعداد مورد نیاز کلاس های extrinsic ایجاد کرد و از یک استخر شی در کلاس factory، شی از کلاس های دارای صفات intrinsic را دریافت و به رفرنس به آن را نگهداری کرد

![image](https://github.com/Peyman-hme/DesignPatternsInUnity/assets/62210041/2ef40564-8f09-48ac-b16f-5a61c5a47df0)

ساختار این الگو را در تصویر زیر مشاهده می کنید:

شبه کد مثالی برای این الگو را در ادامه مشاهده می کنید:
'''
1 // The flyweight class contains a portion of the state of a
2 // tree. These fields store values that are unique for each
3 // particular tree. For instance, you won't find here the tree
4 // coordinates. But the texture and colors shared between many
5 // trees are here. Since this data is usually BIG, you'd waste a
6 // lot of memory by keeping it in each tree object. Instead, we
7 // can extract texture, color and other repeating data into a
8 // separate object which lots of individual tree objects can
9 // reference.
10 class TreeType is
11   field name
12   field color
13   field texture
14   constructor TreeType(name, color, texture) { ... }
15   method draw(canvas, x, y) is
16    // 1. Create a bitmap of a given type, color & texture.
17    // 2. Draw the bitmap on the canvas at X and Y coords.
18
19 // Flyweight factory decides whether to re-use existing
20 // flyweight or to create a new object.
21 class TreeFactory is
22   static field treeTypes: collection of tree types
23   static method getTreeType(name, color, texture) is
24   type = treeTypes.find(name, color, texture)
25   if (type == null)
26    type = new TreeType(name, color, texture)
27    treeTypes.add(type)
28   return type
29
30 // The contextual object contains the extrinsic part of the tree
31 // state. An application can create billions of these since they
32 // are pretty small: just two integer coordinates and one
33 // reference field.
34 class Tree is
35   field x,y
36   field type: TreeType
37   constructor Tree(x, y, type) { ... }
38   method draw(canvas) is
39    type.draw(canvas, this.x, this.y)
40
41 // The Tree and the Forest classes are the flyweight's clients.
42 // You can merge them if you don't plan to develop the Tree
43 // class any further.
44 class Forest is
45   field trees: collection of Trees
46
47   method plantTree(x, y, name, color, texture) is
48    type = TreeFactory.getTreeType(name, color, texture)
49    tree = new Tree(x, y, type)
50    trees.add(tree)
51
52   method draw(canvas) is
53    foreach (tree in trees) do
54     tree.draw(canvas)
'''










