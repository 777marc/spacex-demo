# SmileDirectClub .NET Core Code Challenge - Marc Mendoza

### API Specification 
* Get All Launch Pads: returns an array of the LaunchPad
  * Example <Server>/api/launchpads

* Get Launch Pad By Id: returns a single LaunchPad by Id
  * Example: ```(server)/api/launchpads/{{id}}```

* Get Launch Pad(s) By Status: returns an array of the LaunchPad filtered by their status of active or retired
  * Example ```(server)/api/launchpads/status/{{ active / retired }}```

* Get Launch Pad(s) By Name Search (Full or Partial): returns an array of the LaunchPad filtered by full_name
  * Example ```(server)/api/launchpads/search/{{ search term }}```

### Data Source Abstraction
I created a Service named LaunchPads which has an Interface that is used to inject the service into the LaunchPadController class which would allow us to swap out the service from an API based service to a database. In the LaunchPad service class I utilized linq to query the results which could be reused when switching to a database.  This assumes that we would use some type of ORM like Entity Framework.

### Testing (14 Unit Tests in total)
I created 2 unit testing classes;  one to test the service itself and the other to test the controller.  They overlap in coverage but they were simple enough to setup so I prefer to overlap when its feasible.  The tests themselves are very basic in that they only assert that an object is returned. Before they're truely production ready,  they should be expanded to compare that objects are equal and that the values returned are what were expected to be returned.

### Logging 
I set up NLog as the app's logger.  In this implementation, it's injected only into the controller and I perform some basic logging on each of the 4 method calls. The log files can be found at C:\temp.  This location can be modified by changning the location the nlog.config.  The verbosity can modified by changing the logging settings in the logging section of the AppSetting.json file.

## Config
I set up an AppSettings class for the SpaceX API URL which is injection into the service.  Down the road when a database is added, the AppSettings class can be used to reference any connection information for the data source.  This aslo makes the service and the app itself more horizontally scalable since each instance can host its own configuration.

## LaunchPad Model Example
```
{
  "id": "ccafs_slc_40",
  "name": "Cape Canaveral Air Force Station Space Launch Complex 40",
  "status": "active"
} 
```