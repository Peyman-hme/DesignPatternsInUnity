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
![الگو طراحی Singleton](https://previews.dropbox.com/p/thumb/AB9E308dgFsWKixYlRyc81RivAl91rWHJ7Kq6Kc6JxG67GWNkNNDy-5JSuCER6KhzctMq8C5HVjDY5pbQZJorH8ukcx-q8jcNdYmvxDJxPPlqOAQd_VPN18dhDBHeQ5gptAfeBXkXt-TNFHGXiU_a2jrkFl1UpnO1Nrh5GGy8-IpfOUlCRTrW5cYANGfdzYRhUHrovJCv0O88K-ixUpV0DqW4mAuCHHQ3N4qGVE9aICde8GLoq2FkkHj8rAs-LuT8y-hLbiaQ2LMDpFrMXKb9LqRg4FkuxwcTjeFJhGumMGwXaopMsvolvpNXeUyNJeIm_4eQfZ1RxTyLWU9-rl3jQNa/p.png)


