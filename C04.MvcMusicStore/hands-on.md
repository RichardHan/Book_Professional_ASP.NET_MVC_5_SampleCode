
Create MVC Project.

Create 'Album' 'Artist' 'Genre' three simple public class

	public class Album
	{
	    public virtual int AlbumId { get; set; }
	    public virtual int GenreId { get; set; }
	    public virtual int ArtistId { get; set; }
	    public virtual string Title { get; set; }
	    public virtual decimal Price { get; set; }
	    public virtual string AlbumArtUrl { get; set; }
	    public virtual Genre Genre { get; set; }
	    public virtual Artist Artist { get; set; }
	}

    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
    }

    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }

[Optional] Create EF's code-first class (MusicStoreDB.cs)

    public class MusicStoreDB : DbContext
    { 
    	//name of connecion string
        public MusicStoreDB() : base("name=MusicStoreDB")
        {
        }
       
        public System.Data.Entity.DbSet<Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<Models.Genre> Genres { get; set; }    
    }

[Optional] Add MusicStoreDB connection string in web.config (must installed localdb first)

	<connectionStrings>
	    <add name="MusicStoreDB" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MusicStoreDB-20130929160340; Integrated Security=True; MultipleActiveResultSets=True; AttachDbFilename=|DataDirectory|MusicStoreDB-2016061914000.mdf"
	      providerName="System.Data.SqlClient" />
	</connectionStrings>

Executing the Scaffolding Template
	
	add controller > MVC 5 Controller with views, using EF. 
		Model classname: Album
		Data context class: MusicStoreDB (Create new one or use previous MusicStoreDB setting.)
		Controller name: StoreManagerController

View all created class.
	StoreManager View.
	code-first code : MusicStoreDBContext
	StoreManagerController.
	localdb Connection string.

Set Database Initializers global.asax.cs	
    Database.SetInitializer(new DropCreateDatabaseAlways<MusicStoreDBContext>());
    //trick for init
    //todo, remove before go live.
    MusicStoreDBContext _dataCntx = new MusicStoreDBContext();            
    _dataCntx.Database.Initialize(true);

Seeding a Database in EF.

    public class MusicStoreDbInitializer
       : System.Data.Entity.DropCreateDatabaseAlways<MusicStoreDBContext>
    {
        protected override void Seed(MusicStoreDBContext context)
        {
            context.Artists.Add(new Artist { Name = "Jolin" });
            context.Artists.Add(new Artist { Name = "Jay" });
            context.Genres.Add(new Genre { Name = "Pop" });
            context.Genres.Add(new Genre { Name = "Rock" });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "Jay" },
                Genre = new Genre { Name = "Pop" },
                Price = 199,
                Title = "Jay's Fantasy"
            });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "Jolin" },
                Genre = new Genre { Name = "Pop" },
                Price = 199,
                Title = "Jolin 1019"
            });
            base.Seed(context);
        }
    }

    //add in global.asax.cs	   
    Database.SetInitializer(new MusicStoreDbInitializer());


Combine Initializer all in global.asax.cs	

    Database.SetInitializer(new DropCreateDatabaseAlways<MusicStoreDBContext>());
    
    Database.SetInitializer(new MusicStoreDbInitializer());

    MusicStoreDBContext _dataCntx = new MusicStoreDBContext();
    _dataCntx.Database.Initialize(true);


Enable EF sql dump , EF version above v6.1 (devlopement suggestion)

  Update-Package -Reinstall "EntityFramework" , add reference "System.Data.Entity"

  ...
  <entityFramework>
    ...
    <interceptors>
      <interceptor type="System.Data.Entity.Infrastructure.Interception.DatabaseLogger, EntityFramework">
        <parameters>
          <parameter value="C:\Temp\LogOutput.txt"/>
        </parameters>
      </interceptor>
    </interceptors>
  </entityFramework>
  ...

Overview - Building a Resource to Edit an Album


Default binding

	[HttpPost]
	public ActionResult Edit(Album album)
	{
	// ...
	}

	public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)

	VS

    public ActionResult Edit()	
    	var album = new Album();
		album.Title = Request.Form["Title"];
		album.Price = Decimal.Parse(Request.Form["Price"]);
