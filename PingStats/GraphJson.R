library(jsonlite)
library(ggplot2)
pingStats <- fromJSON("bin/Debug/linuxforcynics.com_2.json")

stats <- data.frame(pingStats) # convert the data to a data.frame
stats.index <- data.frame(1:length(pingStats)) # new row to bind

stats.Combined <- cbind(stats,stats.index)
names(stats.Combined) <- c("ms", "index")

plot <- ggplot(stats.Combined, aes(x = stats.Combined$index ,
                                   xmin = stats.Combined$index,
                                   y = stats.Combined$ms ,
                                   ymin = stats.Combined$ms + 25
                                   )) +
        geom_area(size = 1 , alpha = 0.1) +
        geom_point()
plot
