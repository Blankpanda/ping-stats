library(jsonlite)
library(ggplot2)
pingStats <- fromJSON("bin/Debug/ubuntu.com_0.json")
statusStats <- fromJSON("bin/Debug/status_ubuntu.com_0.json")

stats <- data.frame(pingStats) # convert the data to a data.frame
status <- data.frame(statusStats)

stats.index <- data.frame(1:length(pingStats)) # new row to bind to stats

stats.Combined <- cbind(stats,stats.index)
stats.Combined <- cbind(stats.Combined,status)

names(stats.Combined) <- c("ms", "index", "status")

plot <- ggplot(stats.Combined, aes(x = stats.Combined$index ,
                                   xmin = stats.Combined$index,
                                   y = stats.Combined$ms ,
                                   ymin = stats.Combined$ms + 75
                                   )) +
        geom_area(size = 1 , alpha = 0.1) +
        geom_point( ) +
        geom_line() 
plot
