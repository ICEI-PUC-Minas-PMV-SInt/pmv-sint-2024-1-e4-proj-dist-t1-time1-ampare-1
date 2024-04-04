# Trade-offs de características de qualidade

Seguindo o modelo FURPS+, o trade-off de requisitos não funcionais para o projeto Ampare tem essas categorias:

1. **Usabilidade**: 
   
 - Interface intuitiva: Uma plataforma fácil de navegação para voluntários e ONGs, com um processo de cadastro simples e funcionalidades claras para inscrição de voluntários e gestão dos projetos pelas ONGs.
- Trade-off: Melhorar a usabilidade pode exigir recursos para design de UI/UX, o que pode afetar o desempenho.

2. **Desempenho**: 
   
- Resposta rápida e atualizações em tempo real: Importante para a dinâmica da platafomra em resposta à grandes demandas.
- Trade-off: Otimizar para o melhor desempenho pode conflitar com a usabilidade se desenvolver uma interface mais complexa, além de pode aumentar os custos devido ao uso de mais recursos.

3. **Confiabilidade**: 
   
- Disponibilidade e estabilidade: A plataforma deve ser confiável e estar disponível 24/7, especialmente durante picos de uso em caso de muitas demandas.
- Trade-off: Alta confiabilidade pode exigir mais custos em infraestrutura de backend e isso pode impactar nos custos e na escolha de soluções do sistema.

4. **Suportabilidade**: 
   
- Manutenção e inovação:  A aplicação deve ser fácil de manter e atualizar para receber novas funcionalidades.
- Trade-off: Priorizar a suportabilidade pode limitar ao uso de novas tecnologias, sendo importante escolher tecnologias que ofereçam um bom equilíbrio entre inovação e facilidade de manutenção.


**Requisitos complementares**:
- Implementação: A escolha do framework e da linguagem de programação deve facilitar o desenvolvimento e a manutenção.
- Interface: As APIs devem ser bem documentadas e fáceis de consumir para integração com outras plataformas e serviços.
- Operação: A infraestrutura deve ser escalável e usar soluções em nuvem que possam se adaptar às demandas.
- Requisitos legais: Conformidade com regulamentações de privacidade de dados (LGPD).


### Matriz de Importância Relativa

| Categoria         | Usabilidade | Desempenho | Confiabilidade | Suportabilidade |
|-------------------|-------------|------------|----------------|-----------------|
| **Usabilidade**   | -           | >          | >              | >               |
| **Desempenho**    | <           | -          | <              | >               |
| **Confiabilidade**| <           | >          | -              | >               |
| **Suportabilidade**| <          | <          | <              | -               |

Na matriz acima, o sinal ">" indica que a categoria da linha é mais importante que a categoria da coluna, e o sinal "<" indica que a categoria da linha é menos importante que a categoria da coluna. Por exemplo, a Usabilidade é considerada mais importante que o Desempenho, Confiabilidade e Suportabilidade, enquanto o Desempenho é considerado mais importante que a Suportabilidade, mas menos importante que a Usabilidade e Confiabilidade, e assim por diante.
