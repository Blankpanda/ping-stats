library(jsonlite)

pingStats <- fromJSON("bin/Debug/stats_0.json")

pingStats

plot(pingStats)