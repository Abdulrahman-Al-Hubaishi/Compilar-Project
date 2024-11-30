grammar MyGrammer;




STARTPROGRAM : 'StartP';
ENDPROGRAM : 'EndP';
INT : 'int';
IF : 'if';
ELSEIF : 'elseif';
ELSE : 'else';
FOR : 'for';
INCREASE : '++';
DECREASE : '--';
PRINTT : 'print';

ID : [a-zA-Z_] [a-zA-Z_0-9]*;

STRING : '"' ( ~["\\] | '\\' . )* '"';
NUMBER : [0-9]+;
ASSIGNMENT : '=';
LIFT : '(';
RIGHT : ')';
BEGIN  : '{' ;

PLUS : '+' ;

MINUS : '-' ;

DIV : '/' ;

MUL : '*' ;

MOD : '%';

NEWLINE : '\n';


END : '}' ;
SEMI : ';';   
COMMA : ',';  
GT  : '>' ;
LT : '<' ;
GTORE : '>=';
LTORE : '<=';
EQUAL : '==';
NOTEQUAL : '!=';
BREAKE : [break];
WS : [ \t\r\n]+ -> skip;
INVALID : . ;




program : STARTPROGRAM (statements)* ENDPROGRAM ;

declarlist : declar (COMMA declar2)* SEMI; 


forStatement : FOR LIFT (firstPart)? SEMI  (condition)? SEMI (lastPart)? RIGHT '{' statements  '}' ;



ifStatement : IF LIFT condition RIGHT '{' statements  '}' (elseifStatement)* (elseStatement)? ;

elseifStatement : ELSEIF LIFT condition RIGHT '{' statements  '}';

elseStatement : ELSE '{' statements  '}';


declar : INT ID ASSIGNMENT expr 
       | INT ID  
       ;

declar2 : ID ASSIGNMENT expr
        | ID
        ;

firstPart : INT ID ASSIGNMENT expr 
          | ID ASSIGNMENT expr 
          ;

lastPart : ID INCREASE 
         | ID DECREASE
         ;

condition : expr (GT|LT|GTORE|LTORE|EQUAL|NOTEQUAL) expr ;

statements : declarlist
           | forStatement
           | ifStatement  
           | prints  
           ;


prints : PRINTT LIFT (STRING | expr)?  (COMMA expr)?  RIGHT SEMI ;

expr
    : expr PLUS term   
    | expr MINUS term  
    | term             
    ;

term
    : term MUL factor  
    | term DIV factor
    | term MOD factor
    | factor           
    ;

factor
    : NUMBER          
    | LIFT expr RIGHT  
    | ID
    ;



