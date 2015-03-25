# RequestPipelilne

Request pipeline

This design is a Piline Filter pattern to achieve Chain of responsibility.
Using this we can make calls build a chain of activities that we want to perform in a sequential manner.
This design will allow us to create multiple modules performing diffrent functionality and call them in a sequential manner.

I have tried to put some comments where ever I felt it was appropriate.

The current sample:

in the current sapmle it makes a call to a public rest api
"http://maps.googleapis.com/maps/api/geocode/json?address=Wakad"
recieves data and based on the requested format returns the 
data in the desired format.(currently on ly Json and XML)

It only supports Get's
It only supports Json and XML output at the moment.

The solution has  5 projects 
1. Request.Client
	 the console application the execute the applciations
2. Request.Formatter
	the filter that is responsible to fileter thet content of the pipeline in the required format
3. Request.Pipeline.Core
	the core that builds up teh pipeline
4. Request.Requester
	the filter that makkes the rest request
5. Request.Types
	the projects that store the types 

Dependencies
1.RestSharp nuget package
2.NewtonSoft (the Json Thing)


This I did not end up doing

1. Could have avoided the use of the base carier object, this will remove the need for us to update the Types project
2. Would have loved to write testcases (I wrote test method(s) instead :))
3. Would have used some DI frameworks like niject/structuremap somewhere as least to get the filter's into the pieline.
4. Exception Handeling could also have been done such that I end up returning the exact reason of failure in the pipeline,
   I started thinking of a back error propogation way and ended up with just a simple try catch for now.


The inspiration comes from the http://www.agileatwork.com/tamarack-chain-of-responsibility-framework-for-net/
Though I coudent end up makeing it as the framework above .
the solution that i have made just works for now.
