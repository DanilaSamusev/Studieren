library(shiny)
library(readxl)
library(ggplot2)
library(ggrepel)

ui <- fluidPage(
  
  titlePanel("Прогнозирование рейтинга Белорусско-Российского университета"),
  
  sidebarLayout(
    
    sidebarPanel(
      
      selectInput("dataset", "Выберите регрессию:",
                  choices = c("линейная", "логарифмическая", 
                              "экспоненциальная", "степенная", 
                              "полиномиальная")),
      
      numericInput("pub", 
                   label = h5("Введите количество публикаций:"), 
                   value = 1),  
      p("Данная программа пронозирует рейтинг На основе выбраной модели и количества публикаций,")
    ),
    
    mainPanel(
      tabsetPanel(type = "tabs",
                  tabPanel("Данные", verbatimTextOutput("summary")),
                  tabPanel("Подробнее", withTags({
                    div(class = "header", checked = NA,
                        br(),
                        p(b("Min"), "- минимальное значение набора данных"),
                        p(b("1Q"), " - первый квартиль, который обозначает медиану нижней половины данных"),
                        p(b("Mediana"), "- обозначает число, которое находится в середине набора данных"),
                        p(b("3Q"), "- третий квартиль, который обозначает медиану верхней половины данных"),
                        p(b("Max"), "- максимальное значение набора данных"),
                        br(),
                        p(b("intercept"), "- точка пересечения прямой с осью координат"),
                        p(b("Std. Error"), "- стандартные ошибки рассчитанных коэффициентов"),
                        p(b("t value"),"- значения t-критерия Cтьюдента"),
                        p(b("Pr(>|t|)"), "- Р-значения для каждого t-критерия"),
                        br(),
                        p(b("Residual standard error"), " - оценка стандартного отклонения остатков"),
                        p(b("R-squared"), "— коэффициент детерминации, чем ближе к 1, тем ярче выражена зависимость"),
                        p(b("Adjusted R-squared"), "- скорректированный коэффициент детерминации"),
                        p(b("F-statistics"), "- Используется для оценки значимости модели регрессии в целом, является соотношением", 
                          "объяснимой дисперсии, к необъяснимой. Чем больше значение параметра — тем лучше"),
                        p(b("p-value")," - Это вероятность истинности нуль гипотезы, Если значение p value ниже порогового уровня , то нуль гипотеза ложная"),
                        br()
                    )
                  }))
      ),
      
      h3("Прогноз"),
      verbatimTextOutput("dateText"),
      
      h3("График"),
      plotOutput("plot")
    )
    
  )
)

server <- function(input, output) {
  dip <- read_excel("F:/dip.xlsx")
  x <- dip$x
  y <- dip$y
  universities <- dip$universities
  
  
  "%+%" <- function(...){
    paste0(...)
  }
  
  output$summary <- renderPrint({
    
    if (input$dataset == "линейная") {
      summary(lm(y~x))
    } else if (input$dataset == "логарифмическая") {
        summary(lm(y~log(x)))
    } else if (input$dataset == "экспоненциальная") {
        summary(lm(log(y)~x))
    } else if (input$dataset == "степенная") {
        summary(lm(log(y)~log(x)))
    } else if (input$dataset == "полиномиальная") {
      summary(lm(y ~ poly(x,1)))
    }
    
  })
  
  output$dateText  <- renderText({
    dtf <- data.frame(x = abs(input$pub))
    if (input$dataset == "линейная") {
      
      model <- lm(y~x)
      md <- summary(model)
      if (md$r.squared > 0.7) {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.", "т.к R^2 > 0.7, значит зависимость хорошо выражена", "",
              "коэффициенты: ", as.character(round(md$coefficients[1],7)),
              as.character(round(md$coefficients[2],7)), "", "прогноз университета:",
              as.character(round(exp(predict(model, dtf)),0)), sep = "\n")
      } else {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.")
      }
      
    } else if (input$dataset == "логарифмическая") {
     
      model <- lm(y~log(x))
      md <- summary(model)
      if (md$r.squared > 0.7) {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.", "т.к R^2 > 0.7, значит зависимость хорошо выражена", "",
              "коэффициенты: ", as.character(round(md$coefficients[1],7)),
              as.character(round(md$coefficients[2],7)), "", "прогноз университета:",
              as.character(round(exp(predict(model, dtf)),0)), sep = "\n")
      } else {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.")
      }
      
    } else if (input$dataset == "экспоненциальная") {
      
      model <- lm(log(y)~x)
      md <- summary(model)
      if (md$r.squared > 0.7) {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.", "т.к R^2 > 0.7, значит зависимость хорошо выражена", "",
              "коэффициенты: ", as.character(round(md$coefficients[1],7)),
              as.character(round(md$coefficients[2],7)), "", "прогноз университета:",
              as.character(round(exp(predict(model, dtf)),0)), sep = "\n")
      } else {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.")
      }
      
    } else if (input$dataset == "степенная") {
      
      model <- lm(log(y)~log(x))
      md <- summary(model)
      if (md$r.squared > 0.7) {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.", "т.к R^2 > 0.7, значит зависимость хорошо выражена", "",
              "коэффициенты: ", as.character(round(md$coefficients[1],7)),
              as.character(round(md$coefficients[2],7)), "", "прогноз университета:",
              as.character(round(exp(predict(model, dtf)),0)), sep = "\n")
      } else {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.")
      }
      
    } else if (input$dataset == "полиномиальная") {
      
      model <- lm(y ~ poly(x,1))
      md <- summary(model)
      if (md$r.squared > 0.7) {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.", "т.к R^2 > 0.7, значит зависимость хорошо выражена", "",
              "коэффициенты: ", as.character(round(md$coefficients[1],7)),
              as.character(round(md$coefficients[2],7)), "", "прогноз университета:",
              as.character(round(exp(predict(model, dtf)),0)), sep = "\n")
      } else {
        paste("R^2 = " %+% as.character(round(md$r.squared,4)) %+% " означает, что только " 
              %+% as.character(round(md$r.squared*100),0) %+% "% вариации места в рейтинге, 
описываемого данной моделью объясняется количеством публикаций.")
      }
      
    }
  })
  
  output$plot <- renderPlot({
    DF <- data.frame(x, y, universities)
    if (input$dataset == "линейная") {
      
      ggplot(DF, aes(x, y, label = universities)) +
        geom_point() +
        stat_smooth(method = 'lm',formula = y ~ x, se = FALSE) +
        geom_text_repel() +
        theme_bw() +
        theme(legend.title = element_blank(), legend.position="bottom", legend.spacing.x = unit(0.5, "lines")) +
        xlab('Количество публикаций') +
        ylab('Место в рейтинге')
      
    } else if (input$dataset == "логарифмическая") {
      
      ggplot(DF, aes(x, y, label = universities)) +
        geom_point() +
        stat_smooth(method = 'nls', formula = y ~ a * log(x) + b, 
                    se = FALSE, method.args = list(start = c(a = 1, b = 1))) +
        geom_text_repel() +
        theme_bw() +
        theme(legend.title = element_blank(), legend.position="bottom", legend.spacing.x = unit(0.5, "lines")) +
        xlab('Количество публикаций') +
        ylab('Место в рейтинге')
      
    } else if (input$dataset == "экспоненциальная") {
      
      ggplot(dip, aes(x, y, label = universities)) +
        geom_point() +
       # stat_smooth(method = 'nls', formula = y ~ a * exp(b * x), 
       #           se = FALSE, method.args = list(start = list(a = 1, b = 1))) +
        geom_text_repel() +
        theme_bw() +
        theme(legend.title = element_blank(), legend.position="bottom", legend.spacing.x = unit(0.5, "lines")) +
        xlab('Количество публикаций') +
        ylab('Место в рейтинге')
      
    } else if (input$dataset == "степенная") {
      
      ggplot(DF, aes(x, y, label = universities)) +
        geom_point() +
        stat_smooth(method = 'nls', formula = y ~ a * (x ** b), 
                    se = FALSE, method.args = list(start = list(a = 1, b = 1))) +
        geom_text_repel() +
        theme_bw() +
        theme(legend.title = element_blank(), legend.position="bottom", legend.spacing.x = unit(0.5, "lines")) +
        xlab('Количество публикаций') +
        ylab('Место в рейтинге')
      
    } else if (input$dataset == "полиномиальная") {
      
      ggplot(dip, aes(x, y, label = universities)) +
        geom_point() +
        stat_smooth(method = 'lm', formula = y ~ poly(x,2), 
                    se = FALSE) +
        geom_text_repel() +
        theme_bw() +
        theme(legend.title = element_blank(), legend.position="bottom", legend.spacing.x = unit(0.5, "lines")) +
        xlab('Количество публикаций') +
        ylab('Место в рейтинге')
      
    }
  })
  
}

shinyApp(ui, server)