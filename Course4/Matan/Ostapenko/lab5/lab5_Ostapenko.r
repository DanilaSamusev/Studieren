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

# Индекс связности линейных перевозок (макс. значение в 2004 г. = 100%)
infr <- WDI(indicator = "IS.SHP.GCNW.XQ", country = "all", start = 2015, end = 2020, extra = TRUE)

infr_hight_income <- subset(infr, income == "High income" & year == 2015)
infr_low_income <- subset(infr, income == "Low income" & year == 2015)
infr_low_mid_income <- subset(infr, income == "Lower middle income" & year == 2015)
infr_up_mid_income <- subset(infr, income == "Upper middle income" & year == 2015 & IS.SHP.GCNW.XQ < 60)
infr_income <- subset(infr, year == 2015 & income != "Aggregates")

summary(infr_hight_income$IS.SHP.GCNW.XQ)
summary(infr_low_income$IS.SHP.GCNW.XQ)
summary(infr_low_mid_income$IS.SHP.GCNW.XQ)
summary(infr_up_mid_income$IS.SHP.GCNW.XQ)

hist(infr_hight_income$IS.SHP.GCNW.XQ)
hist(infr_low_income$IS.SHP.GCNW.XQ)
hist(infr_low_mid_income$IS.SHP.GCNW.XQ)
hist(infr_up_mid_income$IS.SHP.GCNW.XQ)

describeBy(IS.SHP.GCNW.XQ~income, data = infr_income, na.rm = T)
descr <- describeBy(IS.SHP.GCNW.XQ~income+year, data = infr_income, na.rm = T, digits = 2, mat = T)

pd = position_dodge(0.1)
ggplot(infr_income, aes(x = income, y = IS.SHP.GCNW.XQ, color = region, group = region)) + 
  stat_summary(fun.data = median_hilow, geom = 'line', size = 1.5, position = pd) +
  stat_summary(fun.data = median_hilow, geom = 'point', size = 5, position = pd, pch = 15) +
  theme_bw() +
  xlab('Индекс связности линейных перевозок') +
  ylab('%')

shapiro.test(infr_hight_income$IS.SHP.GCNW.XQ)
shapiro.test(infr_low_income$IS.SHP.GCNW.XQ)
shapiro.test(infr_low_mid_income$IS.SHP.GCNW.XQ)
shapiro.test(infr_up_mid_income$IS.SHP.GCNW.XQ)
