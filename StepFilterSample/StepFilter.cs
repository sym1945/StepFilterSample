using System;
using System.Linq;
using System.Collections.Generic;

namespace StepFilterSample
{
    public class StepFilter<TData>
        where TData : class
    {
        public const string ALL = "ALL";


        private IEnumerable<TData> _DatasSource;

        private List<Func<TData, object>> _StepFilters = new List<Func<TData, object>>();

        private List<object> _FilterValues = new List<object>();



        public StepFilter(IEnumerable<TData> datasSource, params Func<TData, object>[] filters)
        {
            _DatasSource = datasSource;
            _StepFilters.AddRange(filters);

            for (int i = 0; i < _StepFilters.Count; i++)
            {
                _FilterValues.Add(ALL);
            }
        }

        public IList<TData> GetResultDatas()
        {
            var filteredItems = GetFilterdItemsByStep(_StepFilters.Count);

            return filteredItems;
        }

        public List<object> GetFilterValues(int step)
        {
            if (step >= _StepFilters.Count)
                return null;

            var filerItems = new List<object> { ALL };

            var dataSource = GetFilterdItemsByStep(step);

            filerItems.AddRange(
                dataSource
                .Select(d => _StepFilters[step].Invoke(d))
                .Distinct()
            );

            return filerItems;
        }

        public void SetFilterValue(int index, object value)
        {
            if (index >= _FilterValues.Count)
                return;

            var oldValue = _FilterValues[index];
            _FilterValues[index] = value;

            if (oldValue.Equals(value) == false)
            {
                for (int i = index + 1; i < _FilterValues.Count; i++)
                {
                    _FilterValues[i] = ALL;
                }
            }
        }

        private List<TData> GetFilterdItemsByStep(int step)
        {
            List<TData> dataSource = _DatasSource.ToList();

            for (int i = 0; i < step; i++)
            {
                var stepFilter = _StepFilters[i];
                var filterValue = _FilterValues[i];

                dataSource = dataSource
                    .Where(d => stepFilter.Invoke(d).Equals(filterValue) || filterValue.Equals(ALL))
                    .ToList();
            }

            return dataSource;
        }


    }
}