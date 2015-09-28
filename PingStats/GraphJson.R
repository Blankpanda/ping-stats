library(jsonlite)
library(ggplot2)
pingStats <- fromJSON("bin/Debug/stats_0.json")

stats <- data.frame(pingStats) # convert the data to a data.frame
stats.index <- data.frame(1:length(pingStats)) # new row to bind

stats.Combined <- merge(stats,stats.index)

