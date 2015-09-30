library(jsonlite)
library(ggplot2)
pingStats <- fromJSON("bin/Debug/pixiv.com_1.json")

stats <- data.frame(pingStats) # convert the data to a data.frame
stats.index <- data.frame(1:length(pingStats)) # new row to bind

stats.Combined <- cbind(stats,stats.index)
names(stats.Combined) <- c("ms", "index")

plot <- ggplot(stats.Combined, aes(x = stats.Combined$index , y = stats.Combined$ms)) +
        geom_area( position = "stack",size = 1, color= "Grey") + 
        geom_point(color="red")
plot
