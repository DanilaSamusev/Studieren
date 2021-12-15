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

# Ожидаемая продолжительность жизни (в годах)
life_expectancy<-WDI(indicator = "SP.DYN.LE00.IN",country ="all",start = 2015,end = 2015)

# Доступ к электричеству (% от всего населения)
electricity_access<-WDI(indicator = "EG.ELC.ACCS.ZS",country ="all",start = 2015,end = 2015)
# Доля иждивенцев на 100 человек трудоспособного населения
age_dep_coeff<-WDI(indicator = "SP.POP.DPND",country ="all",start = 2015,end = 2015)
# Уровень грамотности взрослого населения (% от населения в возрасте 15 лет и старше)
literacy_rate<-WDI(indicator = "SE.ADT.LITR.ZS",country ="all",start = 2015,end = 2015)


sd(na.omit(life_expectancy$SP.DYN.LE00.IN))/mean(na.omit(life_expectancy$SP.DYN.LE00.IN))
sd(na.omit(electricity_access$EG.ELC.ACCS.ZS))/mean(na.omit(electricity_access$EG.ELC.ACCS.ZS))
sd(na.omit(age_dep_coeff$SP.POP.DPND))/mean(na.omit(age_dep_coeff$SP.POP.DPND))
sd(na.omit(literacy_rate$SE.ADT.LITR.ZS))/mean(na.omit(literacy_rate$SE.ADT.LITR.ZS))


data <- cbind(life_expectancy, electricity_access$EG.ELC.ACCS.ZS, age_dep_coeff$SP.POP.DPND, literacy_rate$SE.ADT.LITR.ZS)

names(data)[3]<- "life_expectancy"
names(data)[5]<- "electricity_access"
names(data)[6]<- "age_dep_coeff"
names(data)[7]<- "literacy_rate"

mean_life_expectancy <- mean(data$life_expectancy[which(!is.na(data$life_expectancy))])
mean_electricity_access <- mean(data$electricity_access[which(!is.na(data$electricity_access))])
mean_age_dep_coeff <- mean(data$age_dep_coeff[which(!is.na(data$age_dep_coeff))])
mean_literacy_rate <- mean(data$literacy_rate[which(!is.na(data$literacy_rate))])

describe(data)

data$life_expectancy[which(is.na(data$life_expectancy))] <- mean_life_expectancy
data$electricity_access[which(is.na(data$electricity_access))] <- mean_electricity_access
data$age_dep_coeff[which(is.na(data$age_dep_coeff))] <- mean_age_dep_coeff
data$literacy_rate[which(is.na(data$literacy_rate))] <- mean_literacy_rate

data %>%
  select(life_expectancy, age_dep_coeff, electricity_access, literacy_rate) %>%
  psych::corr.test()


linearRegression = lm(data$life_expectancy ~ data$electricity_access +data$age_dep_coeff+data$literacy_rate)
coefficients(linearRegression)

summary(linearRegression)