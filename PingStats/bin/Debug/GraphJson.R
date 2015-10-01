library(jsonlite)
library(ggplot2)
pingStats <- fromJSON("bin/Debug/google.com_0.json")
statusStats <- fromJSON("bin/Debug/status_google.com_0.json")

stats <- data.frame(pingStats) # convert the data to a data.frame
status <- data.frame(statusStats)

stats.index <- data.frame(1:length(pingStats)) # new row to bind to stats

stats.Combined <- cbind(stats,stats.index)
stats.Combined <- cbind(stats.Combined,status)

names(stats.Combined) <- c("ms", "index", "status")


plot <- ggplot(stats.Combined, aes(x = index ,
                                   xmin =index,
                                   y = ms ,
                                   ymin = ms + 75
                                   )) +
        ggtitle("Ping stats for: ") +
  
        geom_area(size = 1 , fill = "white" , alpha = 0) +
  
        geom_point(mapping=aes(color = status)) +
        geom_line() 
plot
