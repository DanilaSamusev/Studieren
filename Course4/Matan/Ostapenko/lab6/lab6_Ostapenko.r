library(WDI)
library(xtable)
library(openxlsx)
library(psych)
library(sm)
library(ggplot2)
library(tidyverse)
library(dunn.test)
library(rstatix)
library(ggpubr)

infr <- WDI(indicator = "IS.SHP.GCNW.XQ", country = "all", start = 2015, end = 2020, extra = TRUE)

infr_hight_income <- subset(infr, income == "High income" & year == 2015)
infr_low_income <- subset(infr, income == "Low income" & year == 2015)
infr_low_mid_income <- subset(infr, income == "Lower middle income" & year == 2015)
infr_up_mid_income <- subset(infr, income == "Upper middle income" & year == 2015)
infr_low_mid_income2 <- subset(infr, income == "Lower middle income" & year == 2016)

wilcox.test(infr_hight_income$IS.SHP.GCNW.XQ, infr_low_income$IS.SHP.GCNW.XQ)

shapiro.test(infr_low_mid_income2$IS.SHP.GCNW.XQ)

wilcox.test(infr_low_mid_income$IS.SHP.GCNW.XQ, infr_low_mid_income2$IS.SHP.GCNW.XQ, paired = TRUE)
