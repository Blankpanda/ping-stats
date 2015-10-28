# ping-stats
graph results of using the Ping class in C# using R

this application uses C# to obtain ICMP roundtrip times and graphs them using R.


In order for this application to work R 3.2.2 must be installed with the following packages.
```
ggplot2
jsonlite
```

Likewise C# requires JSON.net.

Currently the only way to view the data using GGPLOT is to edit the GraphJson.R file and run in an R IDE.

this can be achieve by editng the FromJSON() functions.

```
  pingStats <- fromJSON("Debug/ *json output file*  ")
  statusStats <- fromJSON("Debug/ *status json output file* ")
```

output files are paired together by numbers.

example output files:
  _grouped together by the number 0_
  
  <b> google.com_0.json </b>
  
  <b> status_google.com_0.json </b>
  
  _grouped together by the number 2_
  
  <b> 192.168.1.1_2.json* </b>
  
  <b> status_192.168.1.1_2.json </b>
